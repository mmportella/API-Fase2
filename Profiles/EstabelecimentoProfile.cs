using API_Fase2.Data.DTO.EstabelecimentoDTO;
using API_Fase2.Models;
using AutoMapper;

namespace API_Fase2.Profiles
{
    public class EstabelecimentoProfile : Profile
    {
        public EstabelecimentoProfile()
        {
            CreateMap<CreateEstabelecimentoDTO, Estabelecimento>();
            CreateMap<Estabelecimento, ReadEstabelecimentoDTO>();
            CreateMap<UpdateEstabelecimentoDTO, Estabelecimento>();
        }
    }
}
