using API_Fase2.Data.DTO.ListaDTO;
using API_Fase2.Models;
using AutoMapper;

namespace API_Fase2.Profiles
{
    public class ListaProfile : Profile
    {
        public ListaProfile()
        {
            CreateMap<CreateListaDTO, Lista>();
            CreateMap<Lista, ReadListaDTO>();
            CreateMap<UpdateListaDTO, Lista>();
        }
    }
}
