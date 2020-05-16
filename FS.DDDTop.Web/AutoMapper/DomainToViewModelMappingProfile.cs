using AutoMapper;
using FS.DDDTop.Domain.Entities;
using FS.DDDTop.Web.Models;

namespace FS.DDDTop.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Reclamacao, ReclamacaoViewModel>();
        }
    }
}
