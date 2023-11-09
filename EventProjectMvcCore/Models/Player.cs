using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventProjectMvcCore.Models
{
    public class Player
    {

        [Key]
        public int PlayerID { get; set; }
        public string PlayerNameSurname { get; set; }
        public string PlayerDOB { get; set; }
        public string PlayerCountry { get; set; }

        [ForeignKey("Team")]
        public int TeamID { get; set; }

        public Team Team { get; set; }






    }
}
