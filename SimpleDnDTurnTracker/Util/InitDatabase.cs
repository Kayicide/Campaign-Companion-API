using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using SimpleDnDTurnTracker.Data;

namespace SimpleDnDTurnTracker.Util
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class InitDatabase
    {
        private readonly RequestDelegate _next;

        public InitDatabase(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class InitDatabaseExtensions
    {
        public static IApplicationBuilder UseInitDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var serviceProvider = scopedServices.ServiceProvider;
            var context = serviceProvider.GetRequiredService<MainContext>();

            MainContextInitialise.Initialise(context);

            return app;
        }
    }
}
