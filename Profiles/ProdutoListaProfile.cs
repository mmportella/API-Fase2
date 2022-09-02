using API_Fase2.Data.DTO.ProdutoListaDTO;
using API_Fase2.Models;
using AutoMapper;

namespace API_Fase2.Profiles
{
    public class ProdutoListaProfile : Profile
    {
        public ProdutoListaProfile()
        {
            CreateMap<CreateProdutoListaDTO, ProdutoLista>();
            CreateMap<ProdutoLista, ReadProdutoListaDTO>();
            CreateMap<UpdateProdutoListaDTO, ProdutoLista>();
        }
    }
}
