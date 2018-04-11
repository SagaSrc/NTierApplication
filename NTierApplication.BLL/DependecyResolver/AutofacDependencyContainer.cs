
using Autofac;
using NTierApplication.BLL.Services;
using NTierApplication.DAL.Base;
using NTierApplication.Entity.Context;
using System;
using System.Threading;
 
 

namespace NTierApplication.BLL.DependecyResolver
{
    public  class AutofacDependencyContainer 
    {
        // Provider that holds the application container.
        private static Autofac.IContainer _container = null;

        // Instance property that will be used by Autofac  
        // to resolve and inject dependencies. 
        public static IContainer Container
        {
            get
            {
                if (_container == null)
                {
                    Mutex mutex = new Mutex();
                    mutex.WaitOne();
                    if (_container == null)
                    {
                        InitRegisterDependency();
                    }
                    mutex.Close();
                }

                return _container;
            }
        }

        private static void InitRegisterDependency()
        {
            try { 
                var builder = new ContainerBuilder();


                builder.Register<IDbContext>(c => new PrjObjectContext()).InstancePerLifetimeScope();

                //repositories
                builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();


                builder.RegisterType<Log4netService>().As<ILogService>().InstancePerLifetimeScope();
                builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
                builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();

           
                _container = builder.Build();

            }catch(Exception){
               
            }
        }
         

    }

   
}
