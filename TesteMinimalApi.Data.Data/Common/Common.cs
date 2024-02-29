using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TesteMinimalApi.Data.Domain.Interface.Base;
using TesteMinimalApi.Data.Domain.Model.Base;

namespace TesteMinimalApi.Data.Data.Common
{
    public class Common : IBase
    {
        private readonly Context _bd;

        public Common(Context bd) => _bd = bd;

        public async Task<T?> Get<T>(int id) where T : Base => await _bd.Set<T>().FirstOrDefaultAsync(a => a.Id == id);

        public async Task<T[]> GetAll<T>() where T : Base => await _bd.Set<T>().ToArrayAsync();

        public async Task<bool> Update<T>(int id, T inputModel) where T : Base
        {
            if (!inputModel.Validade()) return false;
            var model = await _bd.Todos.FindAsync(id);

            if (model is null) return false;

            UpdateGenerico(model, inputModel);

            return await _bd.SaveChangesAsync() == 0 ? false : true;
        }

        public async Task<bool> Create<T>(T todo) where T : Base
        {
            if (!todo.Validade()) return false;

            _bd.Add(todo);
            return await _bd.SaveChangesAsync() == 0 ? false : true;
        }

        public async Task<bool> Delete<T>(int id) where T : Base
        {
            if (await Get<T>(id) is T model)
            {
                _bd.Remove(model);
                return await _bd.SaveChangesAsync() == 0 ? false : true;
            }
            return false;
        }

        public void UpdateGenerico<T, A>(T Original, A Paralela, List<string> Keys = null)
        {
            var ListKeys = new List<string>();
            foreach (PropertyInfo pro in typeof(T).GetProperties())
            {
                bool Valid = false;

                if (Keys != null)
                {
                    Valid = Keys.Where(c => c.ToUpper() == pro.Name.ToUpper()).FirstOrDefault() != null ? true : false;
                }
                else
                {
                    Valid = pro.CustomAttributes.Where(a => String.Compare(a.AttributeType.Name, "KeyAttribute", StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault() != null ? true : false;
                }
                if (!Valid)
                {
                    pro.SetValue(Original, pro.GetValue(Paralela));
                }
            }
        }
    }
}
