using NEFW.Practice.T01.Core.Entity;

namespace NEFW.Practice.T01.Core.Dummy
{
    public class ProjectDataSeeder
    {
        private readonly EmployeeDepartmentDbContext _context;

        public ProjectDataSeeder(EmployeeDepartmentDbContext context)
        {
            _context = context;
        }

        public void SeedProjectData()
        {
            List<Project> projects = new()
            {
                new Project {
                    ProjectName = "Project 1",
                    Location = "Location 1",
                    DepartmentId = 1,
                    EmployeeProjects = new List<EmployeeProject>() // Initialize EmployeeProjects
                },
                new Project {
                    ProjectName = "Project 2",
                    Location = "Location 2",
                    DepartmentId = 2,
                    EmployeeProjects = new List<EmployeeProject>() // Initialize EmployeeProjects
                },
                new Project {
                    ProjectName = "Project 3",
                    Location = "Location 3",
                    DepartmentId = 3,
                    EmployeeProjects = new List<EmployeeProject>() // Initialize EmployeeProjects
                },
                new Project {
                    ProjectName = "Project 4",
                    Location = "Location 4",
                    DepartmentId = 4,
                    EmployeeProjects = new List<EmployeeProject>() // Initialize EmployeeProjects
                },
                new Project {
                    ProjectName = "Project 5",
                    Location = "Location 5",
                    DepartmentId = 5,
                    EmployeeProjects = new List<EmployeeProject>() // Initialize EmployeeProjects
                }
            };

            _context.Projects.AddRange(projects);
            _ = _context.SaveChanges();
        }
    }
}
