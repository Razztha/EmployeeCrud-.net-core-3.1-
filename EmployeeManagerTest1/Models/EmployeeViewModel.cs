using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagerTest1.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Telephone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree")]
        public bool Agree { get; set; }
        [Display(Name ="Department")]
        [Required(ErrorMessage = "Department is required")]
        public int? DepartmentId { get; set; }
    }
}
