using Microsoft.AspNetCore.Http;

namespace TesteMinimalApi.Core.Core.Interface.Base
{
    public interface ICommonCore
    {
        Task<IResult> GetAll<T>() where T : Data.Domain.Model.Base.Base;
        Task<IResult> Get<T>(int id) where T : Data.Domain.Model.Base.Base;
        Task<IResult> Create<T>(T todo) where T : Data.Domain.Model.Base.Base;
        Task<IResult> Update<T>(int id, T inputModel) where T : Data.Domain.Model.Base.Base;
        Task<IResult> Delete<T>(int id) where T : Data.Domain.Model.Base.Base;
    }
}
