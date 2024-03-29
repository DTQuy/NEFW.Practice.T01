namespace NEFW.Practice.T01.Core.Entity
{
    /// <summary>
    /// Represents a project within the organization.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Gets or sets the unique identifier of the project.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        public string ProjectName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the location of the project.
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ID of the department associated with the project.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the collection of employees associated with the project.
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public required ICollection<EmployeeProject> EmployeeProjects { get; set; }

        /// <summary>
        /// Gets or sets the department associated with the project.
        /// </summary>
        public virtual Department? Department { get; set; }
    }
}
