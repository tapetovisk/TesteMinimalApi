using Microsoft.AspNetCore.Http;
using TesteMinimalApi.Core.Core.Interface.Base;
using TesteMinimalApi.Data.Domain.Interface.Base;

namespace TesteMinimalApi.Core.Core.Core.Base
{
    public class CommonCore : ICommonCore
    {
        private readonly IBase _base;

        public CommonCore(IBase Base) => _base = Base;

        public async Task<IResult> Create<T>(T todo) where T : Data.Domain.Model.Base.Base =>
            await _base.Create(todo) ? TypedResults.Created($"/{typeof(T).Name}/{todo.Id}", todo) : TypedResults.NotFound();

        public async Task<IResult> Delete<T>(int id) where T : Data.Domain.Model.Base.Base =>
            await _base.Delete<T>(id) ? TypedResults.Ok() : TypedResults.NotFound();

        public async Task<IResult> Get<T>(int id) where T : Data.Domain.Model.Base.Base
        {
            var Model = await _base.Get<T>(id);
            return Model == null ? TypedResults.NotFound() : TypedResults.Ok(Model);
        }

        public async Task<IResult> GetAll<T>() where T : Data.Domain.Model.Base.Base =>
            TypedResults.Ok(await _base.GetAll<T>());

        public async Task<IResult> Update<T>(int id, T inputModel) where T : Data.Domain.Model.Base.Base =>
            await _base.Update<T>(id, inputModel) ? TypedResults.Ok() : TypedResults.NotFound();
    }
}
