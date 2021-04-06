using ApiService.Resources.About;
using ApiService.Resources.Contact;
using ApiService.Resources.News;
using ApiService.Resources.NewsCategory;
using AutoMapper;
using Repository.Data.Entities;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<News, NewsResource>();
            CreateMap<Category, NewsCategoryResource>();
            CreateMap<Contact, ContactResource>();
            CreateMap<NewsResponse, NewsResponseResource>();
            CreateMap<About, AboutResource>();
            CreateMap<NewsResponse, LastNewsResource>();
        }
    }
}
