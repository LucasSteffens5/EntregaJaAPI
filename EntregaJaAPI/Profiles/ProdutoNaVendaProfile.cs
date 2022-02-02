using AutoMapper;
using EntregaJaAPI.Data.DTOs;
using EntregaJaAPI.Domain.Entities;

namespace EntregaJaAPI.Profiles
{
    public class ProdutoNaVendaProfile : Profile
    {
        public ProdutoNaVendaProfile()
        {
            CreateMap<CriarProdutoNaVendaDto, ProdutoNaVenda>();
        }

    }
}
