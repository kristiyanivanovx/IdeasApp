using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Categories.Queries.GetCategoriesList;
using Application.Features.Ideas;
using Application.Features.Ideas.Commands.CreateIdea;
using Application.Features.Ideas.Commands.DeleteIdea;
using Application.Features.Ideas.Commands.UpdateIdea;
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
            CreateMap<Category, IdeaListViewModel>().ReverseMap();
            CreateMap<Category, IdeaDetailViewModel>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListViewModel>();
            CreateMap<Category, CategoryIdeaListViewModel>();
		
            CreateMap<Category, CreateIdeaCommand>().ReverseMap();
            CreateMap<Category, UpdateIdeaCommand>().ReverseMap();
            CreateMap<Category, DeleteIdeaCommand>().ReverseMap();
		}
	}
}
