using GitHub.Pages.Writer.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GitHub.Pages.Writer.API.Configuration {
    public class CategoryConfiguration : IEntityTypeConfiguration<Category> {
        public void Configure(EntityTypeBuilder<Category> builder) {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        }
    }
}
