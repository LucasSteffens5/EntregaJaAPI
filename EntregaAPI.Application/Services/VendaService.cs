using EntregaJaAPI.Domain.Entities;
using EntregaJaAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregaAPI.Application.Services
{
    public  class VendaService
    {
        private readonly IVendaRepository _vendaRepository;
		private readonly ProdutoService _gerenciadorProdutos;
		private readonly ProdutoNaVendaService _gerenciadorDeProdutosNaVenda;
		private readonly FreteService _calculadorFrete;

		public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

		public void RealizarVenda(Venda venda)
		{
			CalcularValorDoFrete(venda);
			PreencherDataHoraVenda(venda);

			foreach (var produtoNaVenda in venda.ProdutosDaVenda)
			{
				var produto = _gerenciadorProdutos.BuscarProdutoPorIdNaBaseDeDados(produtoNaVenda.IdProduto);

				if (_gerenciadorProdutos.ProdutoNaoEncontrado(produto.Result)) throw new Exception();

				CalcularValorTotalDaVenda(venda, produtoNaVenda, produto.Result);

				_gerenciadorDeProdutosNaVenda.PreecnherDadosBasicosDoProdutoNaVenda(produtoNaVenda, produto.Result);

				_gerenciadorDeProdutosNaVenda.AdicionarProdutoNaVendaNaBaseDeDados(produtoNaVenda);
			}

			AdicionarVendaAoBancoDeDados(venda);
		}

		private void CalcularValorDoFrete(Venda venda)
		{
			venda.ValorFrete = _calculadorFrete.CalcularFrete(venda.Cep);
		}

		private void CalcularValorTotalDaVenda(Venda venda, ProdutoNaVenda produtoNaVenda, Produto produto)
		{
			venda.ValorTotalVenda += produto.Preco * produtoNaVenda.Quantidade;
		}

		private void PreencherDataHoraVenda(Venda venda)
		{
			venda.DataHoraVenda = DateTime.Now;
		}

		private void AdicionarVendaAoBancoDeDados(Venda venda)
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
