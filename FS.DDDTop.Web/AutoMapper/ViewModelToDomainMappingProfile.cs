using AutoMapper;
using FS.DDDTop.Domain.Entities;
using FS.DDDTop.Web.Models;

namespace FS.DDDTop.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ReclamacaoViewModel, Reclamacao>();
        }
    }
}
