using Admin.Models.About;
using Admin.Models.Contact;
using Admin.Models.Manager;
using Admin.Models.News;
using AutoMapper;
using Repository.Data.Entities;

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

            CreateMap<Repository.Data.Entities.Admin, AdminViewModel>();
            CreateMap<AdminViewModel, Repository.Data.Entities.Admin>();
        }
    }
}
