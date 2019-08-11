using AutoMapper;
using FS.DDDTop.Domain.Entities;
using FS.DDDTop.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FS.DDDTop.MVC.AutoMapper
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
