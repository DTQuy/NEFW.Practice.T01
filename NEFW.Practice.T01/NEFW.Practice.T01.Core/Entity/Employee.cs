using System.ComponentModel.DataAnnotations;

namespace NEFW.Practice.T01.Core.Entity
{
    /// <summary>
    /// Represents an employee in the organization.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the unique identifier of the employee.
        /// </summary>
        [Key]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the full name of the employee.
        /// </summary>
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the gender of the employee.
        /// </summary>
        [Required]
        public string Gender { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date of birth of the employee.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [PastDate(ErrorMessage = "Date of birth must be in the past")]
        public DateTimeOffset DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the address of the employee.
        /// </summary>
        [Required]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the salary of the employee.
        /// </summary>
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public string Salary { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the department ID the employee belongs to.
        /// </summary>
        public int DepartmentId { get; set; }

        public virtual ICollection<Project>? Projects { get; set; }
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();

        /// <summary>
        /// Gets or sets the department the employee belongs to.
        /// </summary>
        public virtual Department? Department { get; set; }

        /// <summary>
        /// Sets the full name of the employee.
        /// </summary>
        /// <param name="firstName">The first name of the employee.</param>
        /// <param name="middleName">The middle name of the employee.</param>
        /// <param name="lastName">The last name of the employee.</param>
        public void SetFullName(string firstName, string middleName, string lastName)
        {
            FullName = $"{firstName} {middleName} {lastName}";
        }

        /// <summary>
        /// Custom validation attribute to validate past dates.
        /// </summary>
        public class PastDateAttribute : ValidationAttribute
        {
            public override bool IsValid(object? value)
            {
                return value is DateTimeOffset date && date < DateTimeOffset.Now;
            }
        }
    }
}
