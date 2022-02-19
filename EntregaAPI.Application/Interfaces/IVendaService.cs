using EntregaJaAPI.Domain.Entities;
using System.Collections.Generic;

namespace EntregaAPI.Application.Interfaces
{
    public interface IVendaService
    {
        void RealizarVenda(Venda venda);

        void CalcularValorDoFrete(Venda venda);

        void CalcularValorTotalDaVenda(Venda venda, ProdutoNaVenda produtoNaVenda, Produto produto);

        void PreencherDataHoraVenda(Venda venda);

        void AdicionarVendaAoBancoDeDados(Venda venda);

        Venda BuscarVendaPorId(int id);

        bool VendaNaoEncontrada(Venda venda);

        IEnumerable<Venda> RetornarTodasVendasDaBaseDeDados();

        void CancelarVenda(Venda venda);
    }
}
