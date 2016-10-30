using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcTestPro3_Ninject.Models;
using Ninject;

namespace MvcTestPro3_Ninject.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IShoppingCart>().To<ShoppingCart>();
            _kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            _kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>();
        }
    }
}