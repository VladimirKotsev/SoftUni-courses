namespace SoftUni;

using System.Text;
using System.Globalization;

using SoftUni.Data;
using SoftUni.Models;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();

        Console.WriteLine(GetEmployee147(dbContext));
    }

    //Problem 03.
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
        }

        return sb.ToString();
    }

    //Problem 04.
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} – {e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 05.
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        var employees = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            });

        StringBuilder sb = new StringBuilder();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 06.
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        var address = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };
        var employee = context.Employees
            .First(e => e.LastName == "Nakov");

        employee.Address = address;

        context.SaveChanges();

        var adresses = context.Addresses
            .OrderByDescending(a => a.AddressId)
            .Take(10)
            .Select(a => a.AddressText)
            .ToList();

        StringBuilder sb = new StringBuilder();

        foreach (var a in adresses)
        {
            sb.AppendLine($"{a}");
        }

        return sb.ToString().TrimEnd();

    }

    //Problem 07.
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        var employees = context.Employees
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagersFirstName = e.Manager!.FirstName,
                ManagersLastName = e.Manager!.LastName,
                Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                 ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue
                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                            : "not finished"
                    })
                    .ToArray()
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagersFirstName} {e.ManagersLastName}");
            foreach (var p in e.Projects)
            {
                sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 08.
    public static string GetAddressesByTown(SoftUniContext context)
    {
        var addresses = context.Addresses
            .OrderByDescending(a => a.Employees.Count)
            .ThenBy(a => a.Town.Name)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .Select(a => new
            {
                a.AddressText,
                a.Town.Name,
                a.Employees.Count
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var a in addresses)
        {
            sb.AppendLine($"{a.AddressText}, {a.Name} - {a.Count} employees");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 09.
    public static string GetEmployee147(SoftUniContext context)
    {
        Employee employee = context.Employees
            .First(x => x.EmployeeId == 147);


        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
        var employeeProjects = context.EmployeesProjects.Where(x => x.Employee == employee).ToArray();
        var list = new List<string>();
        foreach (var ep in employeeProjects)
        {
            var project = context.Projects
                .FirstOrDefault(pj => pj.ProjectId == ep.ProjectId);
            list.Add(project!.Name);
        }
        list.Sort();

        return sb.ToString().TrimEnd() + Environment.NewLine + 
            String.Join(Environment.NewLine, list);
    }

    //Problem 10.
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        var departments = context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .ThenBy(d => d.Employees.Count);

        StringBuilder sb = new StringBuilder();

        foreach (var d in departments)
        {
            sb.AppendLine($"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}");
            foreach (var e in d.Employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            }
        }

        return sb.ToString();
    }

    //Problem 11.
    public static string GetLatestProjects(SoftUniContext context)
    {
        var projects = context.Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .OrderBy(p => p.Name)
            .Select(p => new
            {
                p.Name,
                p.Description,
                p.StartDate
            })
            .ToList();


        StringBuilder sb = new StringBuilder();
        foreach (var p in projects)
        {
            sb.AppendLine(p.Name);
            sb.AppendLine(p.Description);
            sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
        }

        return sb.ToString();
    }

    //Problem 12.
    public static string IncreaseSalaries(SoftUniContext context)
    {
        var employees = context.Employees
            .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName);

        StringBuilder sb = new StringBuilder();
        foreach (var e in employees)
        {
            e.Salary *= 1.12m;
        }

        context.SaveChanges();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 13.
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var employees = context.Employees
            .Where(e => e.FirstName.ToLower().StartsWith("sa"))
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            });

        StringBuilder sb = new StringBuilder();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 14.
    public static string DeleteProjectById(SoftUniContext context)
    {
        var pToDelete = context.EmployeesProjects
            .Where(e => e.ProjectId == 2);
        context.EmployeesProjects.RemoveRange(pToDelete);

        var project = context.Projects
            .Find(2);
        context.Projects.Remove(project!);

        context.SaveChanges();

        var projects = context.Projects
            .Take(10)
            .Select(p => new
            {
                p.Name
            });

        StringBuilder sb = new StringBuilder();
        foreach (var p in projects)
        {
            sb.AppendLine($"{p.Name}");
        }

        return sb.ToString().TrimEnd();

    }

    //Problem 15.
    public static string RemoveTown(SoftUniContext context)
    {
        var addressesToDelete = context.Addresses
            .Where(a => a.Town.Name == "Seattle")
            .ToArray();

        var employees = context.Employees
            .Where(e => addressesToDelete.Contains(e.Address))
            .ToArray();

        foreach (var e in employees)
        {
            e.Address = null;
        }

        context.Addresses.RemoveRange(addressesToDelete);
        context.SaveChanges();


        Town townToDelete = context.Towns
            .First(t => t.Name == "Seattle");

        context.Towns.Remove(townToDelete);

        var count = addressesToDelete.Length;

        return $"{count} addresses in Seattle were deleted";
    }
}

