using System.ComponentModel.DataAnnotations;

namespace FlexibleDataApplication.Entities
{
    public class Statistics
    {
        [Key]
        [Required]
        public string Key { get; set; }
        public int Count { get; set; }
        public int UniqueCount { get; set; }

    }
}
