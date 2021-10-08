using AutoMapper;
using EntregaJaAPI.Data.DTOs;
using EntregaJaAPI.Models;

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
