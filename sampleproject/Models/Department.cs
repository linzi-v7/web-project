using System.ComponentModel.DataAnnotations;

namespace sampleproject.Models
{
    public class Department
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Department Phone Number")]
        public int phoneNumber { get; set; }

        [Required]
        [Display(Name = "Department Age")]
        public int age { get; set; }
    }
}
