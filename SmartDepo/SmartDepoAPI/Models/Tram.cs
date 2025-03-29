using System.ComponentModel.DataAnnotations;

namespace SmartDepoAPI.Models
{
    public class Tram
    {
        /// <summary>
        /// Tram Id
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Tram order in which they are available
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Flag for tram's schedule
        /// </summary>
        public bool HasSchedule { get; set; }
    }
}
