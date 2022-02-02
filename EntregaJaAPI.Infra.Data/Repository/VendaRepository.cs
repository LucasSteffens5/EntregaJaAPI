using EntregaJaAPI.Domain.Entities;
using EntregaJaAPI.Domain.Repositories;
using EntregaJaAPI.Infra.Data.Context;

namespace EntregaJaAPI.Infra.Data.Repository
{
    public class VendaRepository : BaseRepository<Venda>, IVendaRepository
    {
        public VendaRepository(DataContext context) : base(context)
        {

        }
    }
}
