using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;


namespace EventProjectMvcCore.Models
{
    public class Event
    {

        [Key]
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDateTime { get; set; }
        public string EventLocation { get; set; }

        public string EventOrganizer { get; set; }

        [ForeignKey("Team")]
        public int TeamID { get; set; }

        public Team Team { get; set; }











    }
}
