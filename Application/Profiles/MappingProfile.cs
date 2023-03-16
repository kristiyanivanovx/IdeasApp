using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Categories.Queries.GetCategoriesList;
using Application.Features.Ideas;
using Application.Features.Ideas.Queries.GetIdeaDetail;
using Application.Features.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<Idea, IdeaListViewModel>().ReverseMap();
            CreateMap<Idea, IdeaDetailViewModel>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListViewModel>();
            CreateMap<Category, CategoryIdeaListViewModel>();
		}
    }
}
