using NEFW.Practice.T01.Core.Entity;

namespace NEFW.Practice.T01.DataAccessLayerr.Interface
{
    public interface ISearchRepository
    {
        // Search employee by name
        IEnumerable<Employee> Search(string name);

        // Search employee by name and department name
        IEnumerable<Employee> Search(string name, string department);

        // Search employee by name, department name, and project name
        IEnumerable<Employee> Search(string name, string department, string project);
    }
}
