
using Microsoft.AspNetCore.Authorization;
using TesteMinimalApi.Core.Core.Interface.Base;

namespace TesteMinimalApi.Client.Api.EndPoint.Base
{
    public static class BaseEndpoint
    {
        public static IEndpointRouteBuilder UseBaseEndpoint<T>(this IEndpointRouteBuilder app) where T : Data.Domain.Model.Base.Base
        {
            var GrupApi = app.MapGroup($"/{typeof(T).Name}");

            GrupApi.MapGet("/", [Authorize] async (ICommonCore Common) => await Common.GetAll<T>())
                .WithTags(typeof(T).Name)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "This is a summary",
                    Description = "This is a description"
                });

            GrupApi.MapGet("/{id}", [Authorize] async (int id, ICommonCore Common) => await Common.Get<T>(id))
            .WithTags(typeof(T).Name);

            GrupApi.MapPost("/", [Authorize] async (T todo, ICommonCore Common) => await Common.Create(todo))
            .WithTags(typeof(T).Name);

            GrupApi.MapPut("/{id}", [Authorize] async (int id, T inputTodo, ICommonCore Common) => await Common.Update(id, inputTodo))
                .WithTags(typeof(T).Name);

            GrupApi.MapDelete("/{id}", [Authorize] async (int id, ICommonCore Common) => await Common.Delete<T>(id))
                .WithTags(typeof(T).Name);

            return GrupApi;
        }
    }
}
