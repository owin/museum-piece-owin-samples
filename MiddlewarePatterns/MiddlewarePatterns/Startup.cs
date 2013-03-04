using Owin;
using Owin.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePatterns
{
    public partial class Startup
    {
        // Add components to the request processing pipeline in expected execution order.
        public void Configuration(IAppBuilder app)
        {
            // Owin.Types based Lambda
            app.UseFilter(request =>
            {
                // Observe the request, but let it pass through
                Helpers.AddBreadCrumb(request, "Owin.Types based Lambda");
            });

            // Raw Lambda
            app.UseFunc(next => environment =>
            {
                // Observe the request, but let it pass through
                Helpers.AddBreadCrumb(environment, "Raw OWIN Lambda");
                return next(environment);
            });

            // Extension methods
            app.UseMyTypeMiddleware("Extension method for MyTypeMiddleware");

            // Type based
            app.UseType<MyTypeMiddleware>("UseType MyTypeMiddleware");
            app.Use(typeof(MyTypeMiddleware), "Use typeof MyTypeMiddleware");

            // Instance based (DI)
            MyInstanceMiddleware instance = new MyInstanceMiddleware();
            app.Use(instance, "Instance of MyInstanceMiddleware");

            // Owin.Types Func
            app.UseHandlerAsync(DisplayBreadcrumbs);
        }

        public Task DisplayBreadcrumbs(OwinRequest request, OwinResponse response)
        {
            response.ContentType = "text/plain";

            string responseText = "Breadcrumbs:\r\n"
                + string.Join("\r\n", request.GetHeaderSplit("breadcrumbs"));

            return response.WriteAsync(responseText);
        }
    }
}
