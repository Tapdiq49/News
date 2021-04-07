using ApiService.Resources.About;
using ApiService.Resources.Contact;
using ApiService.Resources.News;
using ApiService.Resources.NewsCategory;
using AutoMapper;
using Repository.Data.Entities;
using Repository.Models;

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
        }
    }
}
