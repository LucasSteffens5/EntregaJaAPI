using EntregaJaAPI.Data;
using EntregaJaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntregaJaAPI.Assistants
{
	public class GerenciadorDeVendas
	{

		private readonly GerenciadorDeProdutosNaVenda _gerenciadorDeProdutosNaVenda;
		private readonly GerenciadorDeProdutos _gerenciadorProdutos;
		private readonly GerenciadorDeFrete _calculadorFrete;

		public GerenciadorDeVendas()
		{
			_gerenciadorProdutos = new GerenciadorDeProdutos();
			_gerenciadorDeProdutosNaVenda = new GerenciadorDeProdutosNaVenda();
			_calculadorFrete = new GerenciadorDeFrete();
		}
		public void RealizarVenda(Venda venda, DataContext contexto)
		{
			CalcularValorDoFrete(venda);
			PreencherDataHoraVenda(venda);

			foreach (var produtoNaVenda in venda.ProdutosDaVenda)
			{
				var produto = _gerenciadorProdutos.BuscarProdutoPorIdNaBaseDeDados(contexto, produtoNaVenda.IdProduto);

				if (_gerenciadorProdutos.ProdutoNaoEncontrado(produto)) throw new Exception();

				CalcularValorTotalDaVenda(venda, produtoNaVenda, produto);

				_gerenciadorDeProdutosNaVenda.PreecnherDadosBasicosDoProdutoNaVenda(produtoNaVenda, produto);

				_gerenciadorDeProdutosNaVenda.AdicionarProdutoNaVendaNaBaseDeDados(contexto, produtoNaVenda);
			}

			AdicionarVendaAoBancoDeDados(venda, contexto);
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

		private void AdicionarVendaAoBancoDeDados(Venda venda, DataContext contexto)
		{
			contexto.Vendas.Add(venda);
			contexto.SaveChanges();
		}

		public Venda BuscarVendaPorId(DataContext contexto, int id)
		{
			return contexto.Vendas.FirstOrDefault(venda => venda.IdVenda == id);
		}

		public bool VendaNaoEncontrada(Venda venda)
		{
			return venda == null ? true : false;
		}

		public IEnumerable<Venda> RetornarTodasVendasDaBaseDeDados(DataContext contexto)
		{
			return contexto.Vendas;
		}

		public void SalvarContextoDaVenda(DataContext contexto)
		{
			contexto.SaveChanges();
		}

		public void CancelarVenda(Venda venda, DataContext contexto)
		{
			venda.DataHoraCancelamentoVenda = DateTime.Now;
			SalvarContextoDaVenda(contexto);
		}
	}
}
