﻿using aspnetsportwebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace aspnetsportwebapi.Infrastructure
{
    public class CustomResolver:IDependencyResolver, IDependencyScope
    {
        public object GetService(Type serviceType)
        {
            return serviceType == typeof(IRepository)
            ? new ProductRepository()
            : null;
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }
        public void Dispose()
        {
            // do nothing - not required
        }
    }
}