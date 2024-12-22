using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sampleproject.Models
{
    public class Employee
    {
        [Required]
        [Display(Name = "Employee ID")]
        public int id { get; set; }

        [Required]
        [Display(Name ="Employee Name")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Employee Salary")]
        public float Salary { get; set; }

        [Required]
        [Display(Name = "Employee Phone Number")]
        public int phoneNumber { get; set; }

        [Required]
        [Display(Name = "Employee Age")]
        public int age { get; set; }

        [Required]
        [Display(Name = "Image Name")]
        public string image { get; set; }
    }
}
