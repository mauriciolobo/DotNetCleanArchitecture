using CleanArch.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Core.Data.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasData(new Todo{Id = 1, Name = "Genesis", Complete = true}, new Todo { Id = 2, Name = "Chaos", Complete = false });
        }
    }
}