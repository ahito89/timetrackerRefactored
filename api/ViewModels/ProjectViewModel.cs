using System.ComponentModel.DataAnnotations;

namespace api.viewmodels
{
    public class ProjectViewModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}