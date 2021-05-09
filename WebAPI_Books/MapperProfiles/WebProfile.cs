using AutoMapper;
using Model.ModelInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Books.Models;

namespace WebAPI_Books.MapperProfiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<IBooks, BooksViewModel>().ReverseMap();
            CreateMap<IAuthors, AuthorsViewModel>().ReverseMap();
            CreateMap<ILogin, LoginViewModel>().ReverseMap();
            CreateMap<IRegister, RegisterViewModel>().ReverseMap();
        }
    }
}
