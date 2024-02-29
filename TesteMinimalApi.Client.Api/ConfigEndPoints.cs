using TesteMinimalApi.Client.Api.EndPoint;
using TesteMinimalApi.Client.Api.EndPoint.Base;
using TesteMinimalApi.Data.Domain.Model;

namespace TesteMinimalApi.Client.Api
{
    public static class ConfigEndPoints
    {
        public static IEndpointRouteBuilder UseConfigEndPoints(this IEndpointRouteBuilder app)
        {
            app.UseLoginEndPoint();

            app.UseBaseEndpoint<Todo>();
            app.UseBaseEndpoint<Agenda>();

            return app;
        }
    }
}
