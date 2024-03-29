using NEFW.Practice.T01.Core.Entity;

namespace NEFW.Practice.T01.Core.Dummy
{
    public class DataSeeder
    {
        private readonly EmployeeDepartmentDbContext _context;

        public DataSeeder(EmployeeDepartmentDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Seed random data into the database if it's empty.
        /// </summary>
        public void SeedData()
        {
            // Check if there is already data in the database
            if (_context.Departments.Any() || _context.Employees.Any())
            {
                Console.WriteLine("Data already exists in the database. No new data added.");
                return;
            }

            // Generate random departments data
            Department[] departments = new Department[]
            {
                new Department { DepartmentName = "Engineering", Address = "123 Engineering Street" },
                new Department { DepartmentName = "Marketing", Address = "456 Marketing Avenue" },
                new Department { DepartmentName = "Human Resources", Address = "789 HR Boulevard" },
                new Department { DepartmentName = "Finance", Address = "101 Finance Road" },
                new Department { DepartmentName = "Operations", Address = "222 Operations Lane" }
            };

            // Add departments to the context and save changes
            _context.Departments.AddRange(departments);
            _ = _context.SaveChanges();

            // Generate random employees data


            Console.WriteLine("Random data has been successfully added to the database.");
        }
    }
}
