using Microsoft.EntityFrameworkCore;
using NEFW.Practice.T01.Core;
using NEFW.Practice.T01.Core.Entity;
using NEFW.Practice.T01.DataAccessLayerr.Interface;

namespace NEFW.Practice.T01.DataAccessLayerr.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly EmployeeDepartmentDbContext _context;

        public DepartmentRepository(EmployeeDepartmentDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all departments from the database.
        /// </summary>
        /// <returns>A collection of departments.</returns>
        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        /// <summary>
        /// Retrieves a department by its ID.
        /// </summary>
        /// <param name="id">The ID of the department to retrieve.</param>
        /// <returns>The department with the specified ID.</returns>
        public Department GetById(int id)
        {
            return _context.Departments.Find(id) ?? throw new Exception($"Department with ID {id} not found.");
        }

        /// <summary>
        /// Adds a new department to the database.
        /// </summary>
        /// <param name="entity">The department entity to add.</param>
        /// <returns>The added department entity.</returns>
        public Department Add(Department entity)
        {
            _ = _context.Departments.Add(entity);
            _ = _context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Updates an existing department in the database.
        /// </summary>
        /// <param name="entity">The department entity to update.</param>
        /// <returns>True if the department was successfully updated, otherwise false.</returns>
        public bool Edit(Department entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _ = _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Deletes a department from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the department to delete.</param>
        /// <returns>True if the department was successfully deleted, otherwise false.</returns>
        public bool DeleteById(int id)
        {
            Department? department = _context.Departments.Find(id);
            if (department == null)
            {
                return false;
            }

            _ = _context.Departments.Remove(department);
            _ = _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Retrieves departments with paging, based on specified parameters.
        /// </summary>
        /// <param name="pageSize">The size of each page.</param>
        /// <param name="pageIndex">The index of the page to retrieve.</param>
        /// <param name="searchString">The string to search for.</param>
        /// <param name="orderBy">The field to order by.</param>
        /// <returns>A collection of departments based on the specified criteria.</returns>
        public IEnumerable<Department> GetWithPaging(int pageSize, int pageIndex, string searchString, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
