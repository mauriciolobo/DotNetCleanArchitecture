using CleanArch.Core.Data;
using CleanArch.Core.Infra.Logging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Core
{
    public static class Configuration
    {
        public static IServiceCollection AddTodoApp(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Configuration));

            services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            return services;
        }

        public static IServiceCollection AddInMemoryDatabase(this IServiceCollection services)
        {
            services.AddTransient(provider =>
            {
                var ob = new DbContextOptionsBuilder<MyTodoDbContext>();
                ob.UseInMemoryDatabase("InMemoir");
                
                var db = new MyTodoDbContext(ob.Options);
                db.Database.EnsureCreated();

                return db;
            });

            return services;
        }

        public static IServiceCollection AddSqlServerDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddTransient(provider =>
            {
                var ob = new DbContextOptionsBuilder<MyTodoDbContext>();
                ob.UseSqlServer(connectionString);

                var db = new MyTodoDbContext(ob.Options);

                return db;
            });

            return services;
        }
    }
}