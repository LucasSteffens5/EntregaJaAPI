using EntregaAPI.Application.Interfaces;
using EntregaJaAPI.Domain.Entities;
using EntregaJaAPI.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace EntregaAPI.Application.Services
{
    public  class VendaService: IVendaService
	{
        private readonly IVendaRepository _vendaRepository;
		private readonly IProdutoService _gerenciadorProdutos;
		private readonly IProdutoNaVendaService _gerenciadorDeProdutosNaVenda;
		private readonly IFreteService _calculadorFrete;

		public VendaService(IVendaRepository vendaRepository, IProdutoService produtoService, IProdutoNaVendaService produtoNaVendaService , IFreteService freteService)
        {
            _vendaRepository = vendaRepository;
			_gerenciadorProdutos = produtoService;
			_gerenciadorDeProdutosNaVenda = produtoNaVendaService;
			_calculadorFrete = freteService;

		}

		public void RealizarVenda(Venda venda)
		{
			CalcularValorDoFrete(venda);
			PreencherDataHoraVenda(venda);

			foreach (var produtoNaVenda in venda.ProdutosDaVenda)
			{
				var produto = _gerenciadorProdutos.BuscarProdutoPorIdNaBaseDeDados(produtoNaVenda.Id);

				if (_gerenciadorProdutos.ProdutoNaoEncontrado(produto.Result)) throw new Exception();

				CalcularValorTotalDaVenda(venda, produtoNaVenda, produto.Result);

				_gerenciadorDeProdutosNaVenda.PreecnherDadosBasicosDoProdutoNaVenda(produtoNaVenda, produto.Result);

				_gerenciadorDeProdutosNaVenda.AdicionarProdutoNaVendaNaBaseDeDados(produtoNaVenda);
			}

			AdicionarVendaAoBancoDeDados(venda);
		}

		public void CalcularValorDoFrete(Venda venda)
		{
			venda.ValorFrete = _calculadorFrete.CalcularFrete(venda.Cep);
		}

		public void CalcularValorTotalDaVenda(Venda venda, ProdutoNaVenda produtoNaVenda, Produto produto)
		{
			venda.ValorTotalVenda += produto.Preco * produtoNaVenda.Quantidade;
		}

		public void PreencherDataHoraVenda(Venda venda)
		{
			venda.DataHoraVenda = DateTime.Now;
		}

		public void AdicionarVendaAoBancoDeDados(Venda venda)
		{
			_vendaRepository.AddAsync(venda);
		}

		public  Venda BuscarVendaPorId(int id)
			 =>  _vendaRepository.GetByIdAsync(id).Result;


		public bool VendaNaoEncontrada(Venda venda)
		{
			return venda == null ? true : false;
		}

		public IEnumerable<Venda> RetornarTodasVendasDaBaseDeDados()
			=> _vendaRepository.ListAsync().Result;


		public void CancelarVenda(Venda venda)
		{
			venda.DataHoraCancelamentoVenda = DateTime.Now;
			_vendaRepository.UpdateAsync(venda);
		}
      
    }
}
