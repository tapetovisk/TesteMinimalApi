namespace TesteMinimalApi.Data.Domain.Interface.Base
{
    public interface IBase
    {
        Task<T[]> GetAll<T>() where T : Model.Base.Base;
        Task<T?> Get<T>(int id) where T : Model.Base.Base;
        Task<bool> Create<T>(T todo) where T : Model.Base.Base;
        Task<bool> Update<T>(int id, T inputModel) where T : Model.Base.Base;
        Task<bool> Delete<T>(int id) where T : Model.Base.Base;
    }
}
