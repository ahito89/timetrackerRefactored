using System.Collections.Generic;
using data;
using repository;
using System.Linq;

namespace service
{
    public class TimeEntryService : ITimeEntryService
    {
        private IRepository<TimeEntry> timeEntryRepository;

        public TimeEntryService(IRepository<TimeEntry> timeEntryRepository)
        {
            this.timeEntryRepository = timeEntryRepository;
        }

        public IEnumerable<TimeEntry> GetTimeEntries(long id)
        {
            return timeEntryRepository.GetAll().Where(e => e.ProjectId == id);
        }

        public TimeEntry GetTimeEntry(long id)
        {
            return timeEntryRepository.Get(id);
        }

        public void CreateTimeEntry(TimeEntry timeEntry)
        {
            timeEntryRepository.Create(timeEntry);
        }

        public void UpdateTimeEntry(TimeEntry timeEntry)
        {
            timeEntryRepository.Update(timeEntry);
        }

        public void DeleteTimeEntry(long id)
        {
            TimeEntry timeEntry = timeEntryRepository.Get(id);
            if (timeEntry != null)
            {
                timeEntryRepository.Delete(timeEntry);
            }
        }
    }
}
