using System;

namespace data
{
    public class TimeEntry : BaseEntity
    {
        public int MinutesWorked { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
    }
}