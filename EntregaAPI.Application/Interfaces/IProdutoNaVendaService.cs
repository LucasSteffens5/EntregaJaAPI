using EntregaJaAPI.Domain.Entities;

namespace EntregaAPI.Application.Interfaces
{
    public interface IProdutoNaVendaService
    {
        void AdicionarProdutoNaVendaNaBaseDeDados(ProdutoNaVenda produtoNaVenda);

        void PreecnherDadosBasicosDoProdutoNaVenda(ProdutoNaVenda produto, Produto item);

    }
}
