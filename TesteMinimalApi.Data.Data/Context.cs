using Microsoft.EntityFrameworkCore;
using TesteMinimalApi.Data.Domain.Model;

namespace TesteMinimalApi.Data.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
        public DbSet<Agenda> Agendas => Set<Agenda>();
    }
}
