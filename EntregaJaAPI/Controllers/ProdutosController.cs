using AutoMapper;
using EntregaAPI.Application.Interfaces;
using EntregaJaAPI.Data.DTOs;
using EntregaJaAPI.Domain.Entities;
using EntregaJaAPI.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EntregaJaAPI.Controllers
{
    [Route("[controller]")]
	[ApiController]
	public class ProdutosController : ControllerBase
	{
		private IMapper _mapper;
		private readonly IProdutoService _gerenciadorProdutos;

		public ProdutosController(IMapper mapper, IProdutoService produtoService)
		{
			_mapper = mapper;
			_gerenciadorProdutos = produtoService;
		}

		[Route("/CriarProduto")]
		[HttpPost]
		public IActionResult AdicionarProduto([FromBody] CriarProdutoDto produtoDto)
		{
			Produto produto = _mapper.Map<Produto>(produtoDto);

			_gerenciadorProdutos.AdicionarProdutoAoBancoDeDados(produto);

			return CreatedAtAction(nameof(RecuperarProdutoPorId), new { Id = produto.Id }, produto);
		}

		[HttpGet("/ConsultarProduto/{id}")]
		public IActionResult RecuperarProdutoPorId([FromServices] DataContext contexto, int id)
		{
            Produto produto = _gerenciadorProdutos.BuscarProdutoPorIdNaBaseDeDados(id).Result;

            if (_gerenciadorProdutos.ProdutoNaoEncontrado(produto)) return NotFound();

            LerProdutoDto produtoDto = _mapper.Map<LerProdutoDto>(produto);

            _gerenciadorProdutos.RetornarDataHoraDaConsulta(produtoDto);

            return Ok(produtoDto);

        }

        [Route("/ListarProdutos")]
        [HttpGet]
        public IEnumerable<Produto> RecuperarTodosProdutos([FromServices] DataContext contexto)
        {
            return _gerenciadorProdutos.RetornarTodosProdutosDaBaseDeDados().Result;
        }


        [HttpPut("/AtualizarProduto/{id}")]
		public IActionResult AtualizarProdutos(int id, [FromBody] AtualizarProdutoDto produtoDto)
		{
            Produto produto = _gerenciadorProdutos.BuscarProdutoPorIdNaBaseDeDados(id).Result;

            if (_gerenciadorProdutos.ProdutoNaoEncontrado(produto)) return NotFound();

			_gerenciadorProdutos.AtualizarProduto(_mapper.Map(produtoDto, produto));

			return NoContent();
		}

		[HttpDelete("/DeletarProduto/{id}")]
		public IActionResult DeletarProduto([FromServices] DataContext contexto, int id)
		{
            Produto produto = _gerenciadorProdutos.BuscarProdutoPorIdNaBaseDeDados(id).Result;

            if (_gerenciadorProdutos.ProdutoNaoEncontrado(produto)) return NotFound();

            _gerenciadorProdutos.RemoverProdutoDaBaseDeDados(produto);

            return NoContent();
		}

	}
}
