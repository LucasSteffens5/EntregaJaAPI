using EntregaJaAPI.Domain.Entities;
using EntregaJaAPI.Domain.Repositories;
using EntregaJaAPI.Infra.Data.Context;

namespace EntregaJaAPI.Infra.Data.Repository
{
    public class ProdutoNaVendaRepository : BaseRepository<ProdutoNaVenda>, IProdutoNaVendaRepository
    {
        public ProdutoNaVendaRepository(DataContext context) : base(context)
        {
        }
    }
}
