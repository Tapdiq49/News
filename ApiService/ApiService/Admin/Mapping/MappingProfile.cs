using Admin.Models.About;
using Admin.Models.Contact;
using Admin.Models.News;
using AutoMapper;
using Repository.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, ContactViewModel>();
            CreateMap<ContactViewModel, Contact>();

            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();

            CreateMap<About, AboutViewModel>();
            CreateMap<AboutViewModel, About>();

            CreateMap<News, NewsViewModel>();
            CreateMap<NewsViewModel, News>();

            CreateMap<NewsPhoto, NewsPhotoViewModel>();
            CreateMap<NewsPhotoViewModel, NewsPhoto>();
        }
    }
}
