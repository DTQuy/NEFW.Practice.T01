using NEFW.Practice.T01.Core;
using NEFW.Practice.T01.Core.Dummy;

EmployeeDepartmentDbContext context = new();

while (true)
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1: Add dummy departments");
    Console.WriteLine("2: Add dummy employees");
    Console.WriteLine("3: Add dummy projects");
    Console.WriteLine("4: Exit");

    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            AddDummyDepartments(context);
            break;
        case "2":
            AddDummyEmployees(context);
            break;
        case "3":
            AddDummyProjects(context);
            break;
        case "4":
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

/// <summary>
/// Adds dummy departments to the database.
/// </summary>
/// <param name="context">The database context.</param>
void AddDummyDepartments(EmployeeDepartmentDbContext context)
{
    DataSeeder seeder = new(context);
    seeder.SeedData();

    Console.WriteLine("Dummy departments added successfully.");
}

/// <summary>
/// Adds dummy employees to the database.
/// </summary>
/// <param name="context">The database context.</param>
void AddDummyEmployees(EmployeeDepartmentDbContext context)
{
    EmployeeDataSeeder seeder = new(context);
    seeder.SeedEmployeeData();

    Console.WriteLine("Dummy employees added successfully.");
}

/// <summary>
/// Adds dummy projects to the database.
/// </summary>
/// <param name="context">The database context.</param>
void AddDummyProjects(EmployeeDepartmentDbContext context)
{
    ProjectDataSeeder seeder = new(context);
    seeder.SeedProjectData();

    Console.WriteLine("Dummy projects added successfully.");
}
