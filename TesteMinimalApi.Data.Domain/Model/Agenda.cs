namespace TesteMinimalApi.Data.Domain.Model
{
    public class Agenda : Base.Base
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}
