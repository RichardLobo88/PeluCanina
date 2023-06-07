using Microsoft.EntityFrameworkCore;

namespace PeluqueriaCaninaApi.Model
{
    public class TodoApiModel
    {
        public class TodoContext : DbContext
        {
            public TodoContext(DbContextOptions<TodoContext> options)
                : base(options)
            {
            }

            public DbSet<PeluqueriaAPI> TodoItems { get; set; } = null!;
        }

    }
}
