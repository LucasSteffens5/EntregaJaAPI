using AutoMapper;
using EntregaJaAPI.Data.DTOs;
using EntregaJaAPI.Domain.Entities;

namespace EntregaJaAPI.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CriarProdutoDto, Produto>();
            CreateMap<Produto, LerProdutoDto>();
            CreateMap<AtualizarProdutoDto, Produto>();
        }

    }
}
