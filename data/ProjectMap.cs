using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data
{
    public class ProjectMap
    {
        public ProjectMap(EntityTypeBuilder<Project> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(p => p.Description);         
        }
    }
}