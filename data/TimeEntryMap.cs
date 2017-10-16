using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data
{
    public class TimeEntryMap
    {
        public TimeEntryMap(EntityTypeBuilder<TimeEntry> entityBuilder)
        {
            entityBuilder.HasKey( t => t.Id);
            entityBuilder.Property(t => t.MinutesWorked).IsRequired();
            entityBuilder.HasOne(t => t.Project).WithMany(p => p.TimeEntries).HasForeignKey(q => q.ProjectId);
        }
    }
}