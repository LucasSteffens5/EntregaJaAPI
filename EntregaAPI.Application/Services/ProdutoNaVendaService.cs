using EntregaAPI.Application.Interfaces;
using EntregaJaAPI.Domain.Entities;
using EntregaJaAPI.Domain.Repositories;

namespace EntregaAPI.Application.Services
{
    public class ProdutoNaVendaService: IProdutoNaVendaService
    {
        private readonly IProdutoNaVendaRepository _produtoNaVendaRepository;

        public ProdutoNaVendaService(IProdutoNaVendaRepository produtoNaVendaRepository)
        {
            _produtoNaVendaRepository = produtoNaVendaRepository;
        }


        public void AdicionarProdutoNaVendaNaBaseDeDados(ProdutoNaVenda produtoNaVenda)
        {
            _produtoNaVendaRepository.AddAsync(produtoNaVenda);
        }


        public void PreecnherDadosBasicosDoProdutoNaVenda(ProdutoNaVenda produto, Produto item)
        {
            produto.Nome = item.Nome;
            produto.Preco = item.Preco;
        }

    }
}
