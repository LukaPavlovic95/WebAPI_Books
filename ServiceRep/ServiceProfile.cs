using AutoMapper;
using DAL.Entities;
using Model.ModelInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceRep
{
    public class ServiceProfile : Profile 
    {
        public ServiceProfile()
        {
            CreateMap<BooksEntity, IBooks>().ReverseMap();
            CreateMap<AuthorsEntity, IAuthors>().ReverseMap();
            CreateMap<AuthorsEntity, IRegister>().ReverseMap();

        }
    }
}
