using NEFW.Practice.T01.Core;
using NEFW.Practice.T01.Core.Entity;
using NEFW.Practice.T01.DataAccessLayerr.Repositories;

namespace NEFW.Practice.T01.UnitTest.UnitTest
{
    [TestClass]
    public class ProjectRepositoryTests
    {
        private readonly EmployeeDepartmentDbContext _context;

        public ProjectRepositoryTests()
        {
            _context = new EmployeeDepartmentDbContext();
        }

        [TestMethod]
        public void GetAll_Projects_ReturnsAllProjects()
        {
            // Arrange
            ProjectRepository projectRepository = new(_context);

            // Act
            IEnumerable<Project> projects = projectRepository.GetAll();

            // Assert
            Assert.IsNotNull(projects);
            Assert.IsTrue(projects.Any());
        }

        [TestMethod]
        public void GetById_ExistingProjectId_ReturnsProject()
        {
            // Arrange
            ProjectRepository projectRepository = new(_context);
            int projectId = 1;

            // Act
            Project project = projectRepository.GetById(projectId);

            // Assert
            Assert.IsNotNull(project);
            Assert.AreEqual(projectId, project.ProjectId);
        }
    }
}
