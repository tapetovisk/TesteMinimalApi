using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TesteMinimalApi.Data.Data;

namespace TesteMinimalApi.Data.Ioc
{
    public static class Ioc
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
                           options.UseInMemoryDatabase("TodoList"));
            services.AddDatabaseDeveloperPageExceptionFilter();
        }
    }
}
