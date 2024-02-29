using System.ComponentModel.DataAnnotations;

namespace TesteMinimalApi.Data.Domain.Model.Base
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
        public virtual bool Validade() => true;
    }
}
