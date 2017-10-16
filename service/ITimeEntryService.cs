using System;
using System.Collections.Generic;
using data;

namespace service
{
    public interface ITimeEntryService
    {
        IEnumerable<TimeEntry> GetTimeEntries(long id);
        TimeEntry GetTimeEntry(long id);
        void CreateTimeEntry(TimeEntry timeEntry);
        void UpdateTimeEntry(TimeEntry timeEntry);
        void DeleteTimeEntry(long id);
    }
}
