using Microsoft.EntityFrameworkCore;
using NEFW.Practice.T01.Core;
using NEFW.Practice.T01.Core.Entity;
using NEFW.Practice.T01.DataAccessLayerr.Interface;

namespace NEFW.Practice.T01.DataAccessLayerr.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly EmployeeDepartmentDbContext _context;

        public ProjectRepository(EmployeeDepartmentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return _context.Projects.ToList();
        }

        public Project GetById(int id)
        {
            return _context.Projects.Find(id);
        }

        public Project Add(Project entity)
        {
            _ = _context.Projects.Add(entity);
            _ = _context.SaveChanges();
            return entity;
        }

        public bool Edit(Project entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _ = _context.SaveChanges();
            return true;
        }

        public bool DeleteById(int id)
        {
            Project? project = _context.Projects.Find(id);
            if (project == null)
            {
                return false;
            }

            _ = _context.Projects.Remove(project);
            _ = _context.SaveChanges();
            return true;
        }

        public IEnumerable<Project> GetWithPaging(int pageSize, int pageIndex, string searchString, string orderBy)
        {
            // Implement paging logic here
            throw new NotImplementedException();
        }
    }
}
