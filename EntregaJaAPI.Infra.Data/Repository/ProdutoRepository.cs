using EntregaJaAPI.Domain.Entities;
using EntregaJaAPI.Domain.Repositories;
using EntregaJaAPI.Infra.Data.Context;

namespace EntregaJaAPI.Infra.Data.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataContext context) : base(context)
        {
        }
    }
}
