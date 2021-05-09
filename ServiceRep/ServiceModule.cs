using Autofac;
using ServiceRep.Service;
using ServiceRep.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceRep
{
    public static class ServiceModule
    {
        public static void ConfigureRepositoryModule(ContainerBuilder builder)
        {
            builder.RegisterType<BooksService>().As<IBooksService>();
            builder.RegisterType<AuthorsService>().As<IAuthorsService>();
            builder.RegisterType<LoginService>().As<ILoginService>();
            builder.RegisterType<RegisterService>().As<IRegisterService>();

        }
    }
}
