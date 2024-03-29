using Microsoft.EntityFrameworkCore;
using NEFW.Practice.T01.Core;
using NEFW.Practice.T01.Core.Entity;
using NEFW.Practice.T01.DataAccessLayerr.Interface;

namespace NEFW.Practice.T01.DataAccessLayerr.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly EmployeeDepartmentDbContext _context;

        public EmployeeRepository(EmployeeDepartmentDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all employees from the database.
        /// </summary>
        /// <returns>A collection of employees.</returns>
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        /// <summary>
        /// Retrieves an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The employee with the specified ID.</returns>
        public Employee GetById(int id)
        {
            return _context.Employees.Find(id) ?? throw new Exception($"Employee with ID {id} not found.");
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="entity">The employee entity to add.</param>
        /// <returns>The added employee entity.</returns>
        public Employee Add(Employee entity)
        {
            _ = _context.Employees.Add(entity);
            _ = _context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Updates an existing employee in the database.
        /// </summary>
        /// <param name="entity">The employee entity to update.</param>
        /// <returns>True if the employee was successfully updated, otherwise false.</returns>
        public bool Edit(Employee entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _ = _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Deletes an employee from the database by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>True if the employee was successfully deleted, otherwise false.</returns>
        public bool DeleteById(int id)
        {
            Employee? employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return false;
            }

            _ = _context.Employees.Remove(employee);
            _ = _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Retrieves employees with paging, based on specified parameters.
        /// </summary>
        /// <param name="pageSize">The size of each page.</param>
        /// <param name="pageIndex">The index of the page to retrieve.</param>
        /// <param name="searchString">The string to search for.</param>
        /// <param name="orderBy">The field to order by.</param>
        /// <returns>A collection of employees based on the specified criteria.</returns>
        public IEnumerable<Employee> GetWithPaging(int pageSize, int pageIndex, string searchString, string orderBy)
        {
            // Implement paging logic using Skip() and Take() methods
            throw new NotImplementedException();
        }
    }
}
