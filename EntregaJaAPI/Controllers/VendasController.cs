using AutoMapper;
using EntregaAPI.Application.Interfaces;
using EntregaJaAPI.Data.DTOs;
using EntregaJaAPI.Domain.Entities;
using EntregaJaAPI.Infra.Data.Context;
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
		private readonly IVendaService _gerenciadorDeVendas;

		public VendasController(IMapper mapper, IVendaService vendaService)
		{
			_mapper = mapper;
			_gerenciadorDeVendas = vendaService;
		}

		[Route("/RealizarVenda")]
		[HttpPost]
		public IActionResult RealizarVenda([FromServices] DataContext contexto, [FromBody] CriarVendaDto vendaDto)
		{
			Venda venda = _mapper.Map<Venda>(vendaDto);

			try
			{
				_gerenciadorDeVendas.RealizarVenda(venda);
			}
			catch (Exception)
			{
				return BadRequest(); 
			}

			return CreatedAtAction(nameof(RecuperarVendaPorId), new { Id = venda.Id }, venda);
		}



		[HttpGet("/ConsultarVenda/{id}")]
		public IActionResult RecuperarVendaPorId(int id)
		{
            Venda venda = _gerenciadorDeVendas.BuscarVendaPorId( id);

            if (_gerenciadorDeVendas.VendaNaoEncontrada(venda)) return NotFound();

            LerVendaDto vendaDto = _mapper.Map<LerVendaDto>(venda);

            return Ok(vendaDto);
           
		}


        [HttpGet("/HistoricoDeVenda")]
        public IEnumerable<Venda> HistoricoDeVenda()
        {
            return _gerenciadorDeVendas.RetornarTodasVendasDaBaseDeDados();
        }


        [HttpPut("/CancelarVenda/{id}")]
		public IActionResult CancelarVenda(int id)
		{
            Venda venda = _gerenciadorDeVendas.BuscarVendaPorId(id);

            if (_gerenciadorDeVendas.VendaNaoEncontrada(venda)) return NotFound();

            _gerenciadorDeVendas.CancelarVenda(venda);

            return NoContent();
		}

	}
}
