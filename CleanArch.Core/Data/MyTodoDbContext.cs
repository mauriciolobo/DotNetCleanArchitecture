using System.Reflection;
using CleanArch.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Core.Data
{
    public class MyTodoDbContext : DbContext
    {
        public MyTodoDbContext(DbContextOptions<MyTodoDbContext> options):base(options)
        {
            
        }

        public virtual DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}