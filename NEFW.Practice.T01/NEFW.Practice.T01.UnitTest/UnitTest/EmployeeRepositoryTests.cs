using NEFW.Practice.T01.Core;
using NEFW.Practice.T01.Core.Entity;
using NEFW.Practice.T01.DataAccessLayerr.Repositories;

namespace NEFW.Practice.T01.UnitTest.UnitTest
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        private readonly EmployeeDepartmentDbContext _context;

        public EmployeeRepositoryTest()
        {
            _context = new EmployeeDepartmentDbContext();
        }

        /// <summary>
        /// Test to retrieve all employees from the database.
        /// </summary>
        [TestMethod]
        public void GetAll_Employees_Success()
        {
            EmployeeRepository employeeRepository = new(_context);

            IEnumerable<Employee> employees = employeeRepository.GetAll();

            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Any());
        }

        /// <summary>
        /// Test to retrieve an employee by ID from the database.
        /// </summary>
        [TestMethod]
        public void GetById_EmployeeId_Success()
        {
            EmployeeRepository employeeRepository = new(_context);
            int employeeId = 1;

            Employee employee = employeeRepository.GetById(employeeId);

            Assert.IsNotNull(employee);
            Assert.AreEqual(employeeId, employee.EmployeeId);
        }
    }
}
