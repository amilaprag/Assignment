using Assignment.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(50, ErrorMessage = "Name must be 50 characters or less")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the start date")]
        [ValidateDate]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        [StringLength(30, ErrorMessage = "Title must be 30 characters or less")]
        public string Title { get; set; }

        [Display(Name = "Pay Rate")]
        [Required(ErrorMessage = "Please enter a Pay Rate in dollors per hour")]
        [DataType(DataType.Currency)]
        [Range(0, 100, ErrorMessage = "Please enter the Pay Rate between 0 and 100")]
        public decimal PayRate { get; set; }

        [Required(ErrorMessage = "Please enter the hours")]
        [Range(0, 100, ErrorMessage = "Please enter the Pay Rate between 0 and 100")]
        public decimal Hours { get; set; }

        [Required(ErrorMessage = "Please enter the Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}