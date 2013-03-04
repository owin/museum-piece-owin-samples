using MiddlewarePatterns;

namespace Owin
{
    /// <summary>
    /// Adding IAppBuilder extension methods in the OWIN namespace provides developers with
    /// easy ways to add a middleware to the pipeline, and provides strongly typed argument lists.
    /// </summary>
    public static class MyTypeMiddlewareExtensions
    {
        public static IAppBuilder UseMyTypeMiddleware(this IAppBuilder builder, string breadcrumb)
        {
            return builder.Use(typeof(MyTypeMiddleware), breadcrumb);
        }
    }
}