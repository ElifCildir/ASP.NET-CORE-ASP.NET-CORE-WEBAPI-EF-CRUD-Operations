using System.ComponentModel.DataAnnotations;

namespace EventProjectMvcCore.Models
{
    public class Coach
    {
        [Key]
        public int CoachID { get; set; }
        public string CoachNameSurname { get; set; }
        public string CoachCountry { get; set; }
        public string CoachStartDate { get; set; }




    }
}
