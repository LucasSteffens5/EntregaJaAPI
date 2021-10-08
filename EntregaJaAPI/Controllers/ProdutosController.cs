using AutoMapper;
using EntregaJaAPI.Assistants;
using EntregaJaAPI.Data;
using EntregaJaAPI.Data.DTOs;
using EntregaJaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EntregaJaAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ProdutosController : ControllerBase
	{
		private IMapper _mapper;
		private readonly GerenciadorDeProdutos _gerenciadorProdutos;

		public ProdutosController(IMapper mapper)
		{
			_mapper = mapper;
			_gerenciadorProdutos = new GerenciadorDeProdutos();
		}

		[Route("/CriarProduto")]
		[HttpPost]
		public IActionResult AdicionarProduto([FromServices] DataContext contexto, [FromBody] CriarProdutoDto produtoDto)
		{
			Produto produto = _mapper.Map<Produto>(produtoDto);

			_gerenciadorProdutos.AdicionarProdutoAoBancoDeDados(produto, contexto);

			return CreatedAtAction(nameof(RecuperarProdutoPorId), new { Id = produto.IdProduto }, produto);
		}

		[HttpGet("/ConsultarProduto/{id}")]
		public IActionResult RecuperarProdutoPorId([FromServices] DataContext contexto, int id)
		{
			Produto produto = _gerenciadorProdutos.BuscarProdutoPorIdNaBaseDeDados(contexto, id);

			if (_gerenciadorProdutos.ProdutoNaoEncontrado(produto)) return NotFound();

			LerProdutoDto produtoDto = _mapper.Map<LerProdutoDto>(produto);

			_gerenciadorProdutos.RetornarDataHoraDaConsulta(produtoDto);

			return Ok(produtoDto);
		}

		[Route("/ListarProdutos")]
		[HttpGet]
		public IEnumerable<Produto> RecuperarTodosProdutos([FromServices] DataContext contexto)
		{
			return _gerenciadorProdutos.RetornarTodosProdutosDaBaseDeDados(contexto);
		}


		[HttpPut("/AtualizarProduto/{id}")]
		public IActionResult AtualizarProdutos(int id, [FromServices] DataContext contexto, [FromBody] AtualizarProdutoDto produtoDto)
		{
			Produto produto = _gerenciadorProdutos.BuscarProdutoPorIdNaBaseDeDados(contexto, id);

			if (_gerenciadorProdutos.ProdutoNaoEncontrado(produto)) return NotFound();

			_mapper.Map(produtoDto, produto);

			_gerenciadorProdutos.SalvarContextoDoProduto(contexto);

			return NoContent();
		}

		[HttpDelete("/DeletarProduto/{id}")]
		public IActionResult DeletarProduto([FromServices] DataContext contexto, int id)
		{
			Produto produto = _gerenciadorProdutos.BuscarProdutoPorIdNaBaseDeDados(contexto, id);

			if (_gerenciadorProdutos.ProdutoNaoEncontrado(produto)) return NotFound();

			_gerenciadorProdutos.RemoverProdutoDaBaseDeDados(contexto, produto);
			_gerenciadorProdutos.SalvarContextoDoProduto(contexto);
			
			return NoContent();
		}

	}
}
