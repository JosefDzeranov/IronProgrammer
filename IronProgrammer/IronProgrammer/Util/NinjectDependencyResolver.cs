using System;
using System.Collections.Generic;
using System.Web.Mvc;
using IronProgrammer.Domain.Interfaces;
using IronProgrammer.Infrastructure.Business;
using IronProgrammer.Infrastructure.Data;
using IronProgrammer.Infrastructure.Data.Repositories;
using IronProgrammer.Services.Interfaces;
using Ninject;

namespace IronProgrammer.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
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
            _kernel.Bind(typeof(IRepository<>)).To(typeof(ProblemRepository));
            _kernel.Bind<ISolverProblem>().To<TracingSolver>();
        }
    }
}