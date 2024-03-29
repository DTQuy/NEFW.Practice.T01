using NEFW.Practice.T01.Core.Entity;

namespace NEFW.Practice.T01.Core.Dummy
{
    public class EmployeeDataSeeder
    {
        private readonly EmployeeDepartmentDbContext _context;

        public EmployeeDataSeeder(EmployeeDepartmentDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Seed random employee data into the database if it's empty.
        /// </summary>
        public void SeedEmployeeData()
        {
            // Check if there is already data in the database
            if (_context.Employees.Any())
            {
                Console.WriteLine("Employee data already exists in the database. No new data added.");
                return;
            }

            // Generate random employee data
            Random random = new();
            List<Employee> employees = new();
            for (int i = 0; i < 10; i++)
            {
                string gender = random.Next(0, 2) == 0 ? "Male" : "Female";
                DateTimeOffset dateOfBirth = GenerateRandomBirthday();
                decimal salary = random.Next(40000, 90000);

                Employee employee = new()
                {
                    FullName = $"Employee {i + 1}",
                    Gender = gender,
                    DateOfBirth = dateOfBirth,
                    Address = $"Address {i + 1}",
                    Salary = salary.ToString(),
                    DepartmentId = random.Next(1, 6)
                };

                employees.Add(employee);
            }

            // Add employees to the context and save changes
            _context.Employees.AddRange(employees);
            _ = _context.SaveChanges();

            Console.WriteLine("Random employee data has been successfully added to the database.");
        }

        /// <summary>
        /// Generates a random birthday.
        /// </summary>
        private static DateTimeOffset GenerateRandomBirthday()
        {
            Random random = new();
            int year = random.Next(1970, 2006);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            return new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.Zero);
        }
    }
}
