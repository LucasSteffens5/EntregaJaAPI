using EntregaJaAPI.Data.DTOs;
using EntregaJaAPI.Domain.Entities;
using EntregaJaAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntregaJaAPI.Assistants
{
    public class GerenciadorDeProdutos
    {
        private readonly IProdutoRepository _produtoRepository;

        public GerenciadorDeProdutos(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void AdicionarProdutoAoBancoDeDados(Produto produto)
        {
            _produtoRepository.AddAsync(produto);
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
