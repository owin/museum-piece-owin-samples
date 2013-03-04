using Owin.Types;
using System.Collections.Generic;

namespace MiddlewarePatterns
{
    public static class Helpers
    {
        public static void AddBreadCrumb(IDictionary<string, object> environment, string breadcrumb)
        {
            AddBreadCrumb(new OwinRequest(environment), breadcrumb);
        }

        public static void AddBreadCrumb(OwinRequest request, string breadcrumb)
        {
            request.AddHeader("breadcrumbs", breadcrumb);
        }
    }
}