using API_Fase2.Data.DTO.ProdutoDTO;
using API_Fase2.Models;
using AutoMapper;

namespace API_Fase2.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CreateProdutoDTO, Produto>();
            CreateMap<Produto, ReadProdutoDTO>();
            CreateMap<UpdateProdutoDTO, Produto>();
        }
    }
}
