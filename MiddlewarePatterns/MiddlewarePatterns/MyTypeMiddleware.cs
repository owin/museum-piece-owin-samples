using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddlewarePatterns
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    /// <summary>
    /// Middleware using this pattern are added to the pipeline by Type, and then instantiated
    /// during pipeline assembly.
    /// </summary>
    public class MyTypeMiddleware
    {
        private readonly AppFunc _next;
        private readonly string _breadcrumb;

        public MyTypeMiddleware(AppFunc next, string breadcrumb)
        {
            _next = next;
            _breadcrumb = breadcrumb;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            Helpers.AddBreadCrumb(environment, _breadcrumb);
            return _next(environment);
        }
    }
}