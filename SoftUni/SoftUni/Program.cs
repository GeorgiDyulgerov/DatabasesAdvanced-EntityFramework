namespace SoftUni
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftuniContext();
            var str = new StringBuilder();

            #region //Employees full info
            //var employees = context.Employees;

            //foreach (var employee in employees)
            //{

            //    List<string> employeeInfo = new List<string>();
            //    string firstName = employee.FirstName;
            //    string lastName = employee.LastName;
            //    string middleName = employee.MiddleName;
            //    string jobTitle = employee.JobTitle;
            //    decimal salary = employee.Salary;

            //    employeeInfo.Add(firstName);
            //    employeeInfo.Add(lastName);
            //    employeeInfo.Add(middleName);
            //    employeeInfo.Add(jobTitle);
            //    employeeInfo.Add(salary.ToString());
            //    Console.WriteLine(string.Join(" ", employeeInfo));

            //    //str.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary}");
            //}
            #endregion

            #region //Employees with salary over 50k
            //var employeesNames = context.Employees.Where(employee => employee.Salary > 50000).
            //    Select(employee => employee.FirstName);

            //foreach (var employeeName in employeesNames)
            //{
            //    str.AppendLine(employeeName);
            //}
            #endregion

            #region //Employees from Seatle
            //var employees = context.Employees.Where(employee => employee.Department.Name == "Research and Development").
            //    OrderBy(employee => employee.Salary).ThenByDescending(employee => employee.FirstName);

            //foreach (var employee in employees)
            //{
            //    str.AppendLine(
            //        $"{employee.FirstName} {employee.LastName} from {employee.Department.Name} {employee.Salary:##.00}");
            //}
            #endregion

            #region //Add new Address and upd Employee
            ////var address = new Address()
            ////{
            ////    AddressText = "Vitoshka 15",
            ////    TownID = 4
            ////};

            ////Employee nakov = null;
            ////nakov = context.Employees.FirstOrDefault(employee => employee.LastName == "Nakov");
            ////nakov.Address = address;
            ////context.SaveChanges();

            //var addresses = context.Employees.OrderByDescending(address => address.AddressID).Take(10).Select(address => address.Address.AddressText);

            //Console.WriteLine(string.Join("\n",addresses));
            #endregion

            #region //Delete Project by ID

            ////var project = context.Projects.Find(2);

            ////foreach (var employee in project.Employees)
            ////{
            ////    employee.Projects.Remove(project);
            ////}

            ////context.Projects.Remove(project);

            ////context.SaveChanges();

            //var projects = context.Projects.Take(10).Select(pro => pro.Name);
            //str.AppendLine(string.Join("\n", projects));
            #endregion

            #region //Find employees in period

            //var employees =
            //    context.Employees.Where(
            //        employee => employee
            //        .HireDate >= new DateTime(2001,1,1) && employee.HireDate <= new DateTime(2003,1,1)).Take(30);

            //foreach (var employee in employees)
            //{
            //    str.AppendLine($"{employee.FirstName} {employee.LastName} {employee.Manager.FirstName}");

            //    foreach (var project in employee.Projects)
            //    {
            //        str.AppendLine($"—{project.Name} {project.StartDate} {project.EndDate}");
            //    }
            //}

            #endregion

            #region //Address by town name

            //var addresses =
            //    context.Addresses.OrderByDescending(address => address.Employees.Count)
            //        .ThenBy(adderss => adderss.Town.Name)
            //        .Take(10);

            //foreach (var address in addresses)
            //{
            //    str.AppendLine($"{address.AddressText}, {address.Town.Name} – {address.Employees.Count} employees");
            //}

            #endregion

            #region //Employee with id 147 sorted by project names 

            //var employee = context.Employees.Find(147);
            //var employeeProjects = employee.Projects.OrderBy(project => project.Name);

            //str.AppendLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");

            //foreach (var project in employeeProjects)
            //{
            //    str.AppendLine($"--{project.Name}");
            //}

            #endregion

            #region //Departments with more than 5 employees

            //var departments =
            //    context.Departments.Where(department => department.Employees.Count > 5)
            //        .OrderBy(departament => departament.Employees.Count);

            //foreach (var department in departments)
            //{
            //    str.AppendLine($"{department.Name} manager - {department.Manager.FirstName}");

            //    foreach (var employee in department.Employees)
            //    {
            //        str.AppendLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            //    }
            //}

            #endregion

            #region //Find Latest 10 Projects

            //var projects = context.Projects.OrderByDescending(project => project.StartDate).Take(10).OrderBy(project => project.Name);

            //foreach (var project in projects)
            //{
            //    str.AppendLine($"-- {project.Name} {project.Description} {project.StartDate} {project.EndDate}");
            //}

            #endregion

            #region //Increase Salaries

            //var employees =context.Employees.Where(employee =>
            //            employee.Department.Name == "Engineering" || employee.Department.Name == "Tool Design" ||
            //            employee.Department.Name == "Marketing" || employee.Department.Name == "Information Services");

            //foreach (var employee in employees)
            //{                
            //    //employee.Salary += (employee.Salary * 0.12m);

            //    str.AppendLine($"{employee.FirstName} {employee.LastName} ${employee.Salary}");
            //}

            ////context.SaveChanges();


            #endregion

            #region //Remove towns

            //string townToDelete = Console.ReadLine();

            //var town = context.Towns.Where(t => t.Name == townToDelete).First();
            //var addresses = town.Addresses;
            //int counter = addresses.Count;
            //foreach (var address in addresses)
            //{
            //    foreach (var employee in address.Employees)
            //    {
            //        employee.Address = null;
            //    }
            //}
            //context.Addresses.RemoveRange(addresses);
            //context.Towns.Remove(town);
            //context.SaveChanges();

            //str.AppendLine(counter == 1
            //    ? $"{counter} address in {townToDelete} was deleted"
            //    : $"{counter} addresses in {townToDelete} were deleted");

            #endregion

            #region //Find Employees by First Name starting with ‘SA’

            //var employees = context.Employees.Where(employee => employee.FirstName.Substring(0, 2) == "SA");

            //foreach (var employee in employees)
            //{
            //    str.AppendLine($"{employee.FirstName} {employee.LastName} – {employee.JobTitle} - (${employee.Salary})");
            //}

            #endregion

            Console.Write(str);
        }
    }
}
