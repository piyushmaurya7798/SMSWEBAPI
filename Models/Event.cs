using System.ComponentModel.DataAnnotations;

namespace SMSWEBAPI.Models
{
    public class Event
    {
        [Key]
            public int EventId { get; set; }
            public string? Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string? EventType { get; set; } // e.g. "Holiday", "Academic", "Sports"
            public string? Description { get; set; }
        }

}
