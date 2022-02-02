using AutoMapper;
using EntregaJaAPI.Data.DTOs;
using EntregaJaAPI.Domain.Entities;

namespace EntregaJaAPI.Profiles
{
    public class VendaProfile : Profile
    {
        public VendaProfile()
        {
            CreateMap<CriarVendaDto, Venda>();
            CreateMap<Venda, LerVendaDto>();
        }

    }
}
