using System.ComponentModel.DataAnnotations;

namespace api.viewmodels
{
    public class TimeEntryViewModel
    {
        public long Id { get; set; }

        [Required]
        public int MinutesWorked { get; set; }

        [Required]
        public long ProjectId  {get; set; }
    }
}