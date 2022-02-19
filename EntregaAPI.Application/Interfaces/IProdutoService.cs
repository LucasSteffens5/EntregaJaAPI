using EntregaJaAPI.Data.DTOs;
using EntregaJaAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntregaAPI.Application.Interfaces
{
    public interface IProdutoService
    {
        void AdicionarProdutoAoBancoDeDados(Produto produto);

        Task<Produto> BuscarProdutoPorIdNaBaseDeDados(int id);

        bool ProdutoNaoEncontrado(Produto produto);

        Task<IEnumerable<Produto>> RetornarTodosProdutosDaBaseDeDados();

        void RemoverProdutoDaBaseDeDados(Produto produto);

        void RetornarDataHoraDaConsulta(LerProdutoDto produtoDto);

        public void AtualizarProduto(Produto produto);

    }
}
