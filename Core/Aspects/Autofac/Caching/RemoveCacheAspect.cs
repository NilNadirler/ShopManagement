using Core.CrossCuttingConcerns.Caching;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Core.Aspects.Autofac.Caching
{
    public class RemoveCacheAspect:MethodInterception
    {
        private string _patern;

        private ICacheManager _cacheManager;

        public RemoveCacheAspect(string patern)
        {
            _patern = patern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        protected void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_patern);
        }
    }
}
