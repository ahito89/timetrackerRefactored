using System;
using System.Collections.Generic;

namespace data
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TimeEntry> TimeEntries { get; private set; }
        public Guid UserId { get; set; }
    }
}