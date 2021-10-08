using AutoMapper;
using EntregaJaAPI.Data.DTOs;
using EntregaJaAPI.Models;

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
