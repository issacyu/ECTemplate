using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Ninject;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Concrete;
using ECTemplate.WebUI.Infrastructure.Abstract;
using ECTemplate.WebUI.Infrastructure.Concrete;
namespace ECTemplate.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IProductsRepository>().To<EFProductRepository>();

            kernel.Bind<IAccountRepository>().To<EFAccountRepository>();

            kernel.Bind<IOrderRepository>().To<EFOrderRepository>();

            kernel.Bind<IOrderDetailRepository>().To<EFOrderDetailRepository>();

            kernel.Bind<IAddressRepository>().To<EFAddressRepository>();

            kernel.Bind<IAuthProvider>().To<FromsAuthProvider>();

            EmailSettings emailSetting = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };
        }
    }
}