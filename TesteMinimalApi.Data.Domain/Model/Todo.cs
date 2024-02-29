namespace TesteMinimalApi.Data.Domain.Model
{
    public class Todo : Base.Base
    {
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        public override bool Validade() => !string.IsNullOrEmpty(Name);

    }
}
