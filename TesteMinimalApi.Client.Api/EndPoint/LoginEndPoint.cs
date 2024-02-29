using TesteMinimalApi.Core.Core.Core;

namespace TesteMinimalApi.Client.Api.EndPoint
{
    public static class LoginEndPoint
    {
        public static IEndpointRouteBuilder UseLoginEndPoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/login", () => new LoginCore().GetLogin())
                .WithTags("Login");

            return app;
        }
    }
}
