using EntregaJaAPI.Domain.Entities;
using EntregaJaAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregaAPI.Application.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void AdicionarProdutoAoBancoDeDados(Produto produto)
        {
            _produtoRepository.AddAsync(produto);
        }


        public async Task<Produto> BuscarProdutoPorIdNaBaseDeDados(int id)
        {
            return await _produtoRepository.GetByIdAsync(id);
        }

        public bool ProdutoNaoEncontrado(Produto produto)
        {
            return produto == null ? true : false;
        }

        public async Task<IEnumerable<Produto>> RetornarTodosProdutosDaBaseDeDados()
        {
            return await _produtoRepository.ListAsync();
        }

        public async void RemoverProdutoDaBaseDeDados(Produto produto)
        {
            await _produtoRepository.RemoveAsync(produto);
        }

        public void RetornarDataHoraDaConsulta(LerProdutoDto produtoDto)
        {
            produtoDto.HoraDaConsulta = DateTime.Now;
        }
    }
}
