using AutoMapper;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Dtos.AboutDto;
using WebUI.Dtos.ContactDto;
using WebUI.Dtos.ProjectDto;

namespace WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<UpdateProjectDto, Project>().ReverseMap();
            CreateMap<CreateProjectDto, Project>().ReverseMap();
            CreateMap<ResultProjectDto, Project>().ReverseMap();


            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<ResultContactDto, Contact>().ReverseMap();

        }

    }
}
