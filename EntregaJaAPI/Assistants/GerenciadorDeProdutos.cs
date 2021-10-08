using EntregaJaAPI.Data;
using EntregaJaAPI.Data.DTOs;
using EntregaJaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntregaJaAPI.Assistants
{
	public class GerenciadorDeProdutos
	{

		public GerenciadorDeProdutos()
		{

		}

		public void AdicionarProdutoAoBancoDeDados(Produto produto, DataContext contexto)
		{
			contexto.Produto.Add(produto);
			contexto.SaveChanges();
		}


		public Produto BuscarProdutoPorIdNaBaseDeDados(DataContext contexto, int id)
		{
			return contexto.Produto.FirstOrDefault(produto => produto.IdProduto == id);
		}

		public bool ProdutoNaoEncontrado(Produto produto)
		{
			return produto == null ? true : false;
		}

		public IEnumerable<Produto> RetornarTodosProdutosDaBaseDeDados(DataContext contexto)
		{
			return contexto.Produto;
		}

		public void SalvarContextoDoProduto(DataContext contexto)
		{
			contexto.SaveChanges();
		}

		public void RemoverProdutoDaBaseDeDados(DataContext contexto, Produto produto)
		{
			contexto.Remove(produto);
		}

		public void RetornarDataHoraDaConsulta(LerProdutoDto produtoDto)
		{
			produtoDto.HoraDaConsulta = DateTime.Now;
		}
	}
}
