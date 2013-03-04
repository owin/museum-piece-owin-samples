using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddlewarePatterns
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    /// <summary>
    /// Middleware following this pattern can be instantiated before being added to the pipeline
    /// (e.g. by a dependency injection framework).  When the pipeline is assembled the Initialize
    /// method is called to hook up the next pipeline component.
    /// </summary>
    public class MyInstanceMiddleware
    {
        private AppFunc _next;
        private string _breadcrumb;

        public MyInstanceMiddleware()
        {
        }

        public void Initialize(AppFunc next, string breadcrumb)
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