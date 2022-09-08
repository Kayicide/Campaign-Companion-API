using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using SimpleDnDTurnTracker.Data;

namespace SimpleDnDTurnTracker.Util
{
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
