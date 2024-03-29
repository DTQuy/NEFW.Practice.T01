using NEFW.Practice.T01.Core;
using NEFW.Practice.T01.Core.Entity;

namespace NEFW.Practice.T01.DataAccessLayerr.Repositories
{
    /// <summary>
    /// Repository class for searching employees.
    /// </summary>
    public class SearchRepository
    {
        private readonly EmployeeDepartmentDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public SearchRepository(EmployeeDepartmentDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Search employee by name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>A collection of employees matching the provided name.</returns>
        public IEnumerable<Employee> Search(string name)
        {
            return _context.Employees.Where(e => e.FullName.Contains(name)).ToList();
        }

        /// <summary>
        /// Search employee by name and department name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <param name="department">The department name to filter by.</param>
        /// <returns>A collection of employees matching the provided name and department.</returns>
        public IEnumerable<Employee> Search(string name, string department)
        {
            return _context.Employees
                .Where(e => e.FullName.Contains(name) && e.Department.DepartmentName == department)
                .ToList();
        }

        /// <summary>
        /// Search employee by name, department name, and project name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <param name="department">The department name to filter by.</param>
        /// <param name="project">The project name to filter by.</param>
        /// <returns>A collection of employees matching the provided name, department, and project.</returns>
        public IEnumerable<Employee> Search(string name, string department, string project)
        {
            return _context.Employees
                .Where(e => e.FullName.Contains(name) && e.Department.DepartmentName == department &&
                            e.Projects.Any(p => p.ProjectName == project))
                .ToList();
        }
    }
}
