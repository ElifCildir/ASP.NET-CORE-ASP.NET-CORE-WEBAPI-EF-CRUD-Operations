using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventProjectMvcCore.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string TeamLogo { get; set; }
        public int TeamNumberofMember { get; set; }
        public string YearFounded { get; set; }

        [ForeignKey("Coach")]
        public int CoachId { get; set; }

        public Coach Coach { get; set; }






    }
    }
