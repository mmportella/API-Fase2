using API_Fase2.Data.DTO.EstoqueDTO;
using API_Fase2.Models;
using AutoMapper;

namespace API_Fase2.Profiles
{
    public class EstoqueProfile : Profile
    {
        public EstoqueProfile()
        {
            CreateMap<CreateEstoqueDTO, Estoque>();
            CreateMap<Estoque, ReadEstoqueDTO>();
            CreateMap<Estoque, ComparaEstoqueDTO>();
            CreateMap<UpdateEstoqueDTO, Estoque>();
        }
    }
}
