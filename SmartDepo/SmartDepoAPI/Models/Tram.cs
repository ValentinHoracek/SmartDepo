using System.ComponentModel.DataAnnotations;

namespace SmartDepoAPI.Models
{
    public class Tram
    {
        [Key]
        public long Id { get; set; }
        public int Order { get; set; }
        public bool HasSchedule { get; set; }
    }
}
