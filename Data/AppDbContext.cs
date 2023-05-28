
using Microsoft.EntityFrameworkCore;
using Todo_API_ASPNET.Models;

namespace Todo_API_ASPNET.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoModel> Todos{ get; set; }

        // Configurando a conexão com o banco do sqlite
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}
