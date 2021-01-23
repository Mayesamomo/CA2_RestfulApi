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
    public class ModelToResourceProfile : Profile
    {
        //creating a map between the Category model class and the CategoryResource class. 
       //Since the classes’ properties have the same names and types, 
      //
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Anime, AnimeResource>();
            CreateMap<QueryResult<Anime>, QueryResultResource<AnimeResource>>();

        }

    }
    }

