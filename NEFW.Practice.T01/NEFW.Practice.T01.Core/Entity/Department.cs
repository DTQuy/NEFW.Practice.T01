using System.ComponentModel.DataAnnotations;

namespace NEFW.Practice.T01.Core.Entity
{
    /// <summary>
    /// Represents a department in the organization.
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Gets or sets the unique identifier of the department.
        /// </summary>
        [Key]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        [Required]
        public string DepartmentName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the address of the department.
        /// </summary>
        [Required]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the collection of employees in this department.
        /// </summary>
        public virtual ICollection<Employee>? Employees { get; set; }
        public virtual ICollection<Project>? Projects { get; set; }
    }
}
