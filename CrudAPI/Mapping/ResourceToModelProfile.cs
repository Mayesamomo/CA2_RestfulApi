using AutoMapper;
using CrudAPI.Domain.Models;
using CrudAPI.Domain.Models.Queries;
using CrudAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();

            CreateMap<SaveAnimeResource, Anime>();
            //    .ForMember(src => src.Category, opt => opt.MapFrom(src => (Category)src.Category));

            CreateMap<AnimesQueryResource, AnimesQuery>();
        }
    }
}
