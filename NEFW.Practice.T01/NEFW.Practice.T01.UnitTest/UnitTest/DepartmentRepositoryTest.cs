using NEFW.Practice.T01.Core;
using NEFW.Practice.T01.Core.Entity;
using NEFW.Practice.T01.DataAccessLayerr.Repositories;

namespace NEFW.Practice.T01.UnitTest.UnitTest
{
    [TestClass]
    public class DepartmentRepositoryTest
    {
        private readonly EmployeeDepartmentDbContext _context;

        public DepartmentRepositoryTest()
        {
            _context = new EmployeeDepartmentDbContext();
        }

        /// <summary>
        /// Test to retrieve all departments from the database.
        /// </summary>
        [TestMethod]
        public void GetAll_Departments_Success()
        {
            DepartmentRepository departmentRepository = new(_context);

            IEnumerable<Department> departments = departmentRepository.GetAll();

            Assert.IsNotNull(departments);
            Assert.IsTrue(departments.Any());
        }

        /// <summary>
        /// Test to retrieve a department by ID from the database.
        /// </summary>
        [TestMethod]
        public void GetById_DepartmentId_Success()
        {
            DepartmentRepository departmentRepository = new(_context);
            int departmentId = 1;
            Department department = departmentRepository.GetById(departmentId);

            Assert.IsNotNull(department);
            Assert.AreEqual(departmentId, department.DepartmentId);
        }
    }
}
