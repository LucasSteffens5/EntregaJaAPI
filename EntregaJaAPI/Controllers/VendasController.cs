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
	public class VendasController : ControllerBase
	{
		private IMapper _mapper;
		private readonly GerenciadorDeVendas _gerenciadorDeVendas;

		public VendasController(IMapper mapper)
		{
			_mapper = mapper;
			_gerenciadorDeVendas = new GerenciadorDeVendas();
		}

		[Route("/RealizarVenda")]
		[HttpPost]
		public IActionResult RealizarVenda([FromServices] DataContext contexto, [FromBody] CriarVendaDto vendaDto)
		{
			Venda venda = _mapper.Map<Venda>(vendaDto);

			try
			{
				_gerenciadorDeVendas.RealizarVenda(venda, contexto);
			}
			catch (Exception)
			{
				return BadRequest(); 
			}

			return CreatedAtAction(nameof(RecuperarVendaPorId), new { Id = venda.IdVenda }, venda);
		}



		[HttpGet("/ConsultarVenda/{id}")]
		public IActionResult RecuperarVendaPorId([FromServices] DataContext contexto, int id)
		{
			Venda venda = _gerenciadorDeVendas.BuscarVendaPorId(contexto, id);

			if (_gerenciadorDeVendas.VendaNaoEncontrada(venda)) return NotFound();

			LerVendaDto vendaDto = _mapper.Map<LerVendaDto>(venda);

			return Ok(vendaDto);
		}


		[HttpGet("/HistoricoDeVenda")]
		public IEnumerable<Venda> HistoricoDeVenda([FromServices] DataContext contexto)
		{
			return _gerenciadorDeVendas.RetornarTodasVendasDaBaseDeDados(contexto);
		}


		[HttpPut("/CancelarVenda/{id}")]
		public IActionResult CancelarVenda(int id, [FromServices] DataContext contexto)
		{
			Venda venda = _gerenciadorDeVendas.BuscarVendaPorId(contexto, id);

			if (_gerenciadorDeVendas.VendaNaoEncontrada(venda)) return NotFound();			

			_gerenciadorDeVendas.CancelarVenda(venda ,contexto);
			
			return NoContent();
		}

	}
}
