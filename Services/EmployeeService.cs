using sample.Models;

namespace sample.Services;

public static class EmployeeService
{
    static List<Employee> employees { get; }
    static int nextId = 4;
    static EmployeeService()
    {
        employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Priyanka", Contact=231231234 , department="Software developer"},
            new Employee { Id = 2, Name = "Pavan",Contact=231331234 , department="Senior Software developer"},
            new Employee { Id = 3, Name = "Ashok",Contact=121531634 , department="Software developer"}
        };
    }

    public static List<Employee> GetAll() => employees;

    public static Employee? Get(int id) => employees.FirstOrDefault(p => p.Id == id);

    public static void Add(Employee employee)
    {
        employee.Id = nextId++;
        employees.Add(employee);
    }

    public static void Delete(int id)
    {
        var employee = Get(id);
        if(employee is null)
            return;

        employees.Remove(employee);
    }

    public static void Update(Employee employee)
    {
        var index = employees.FindIndex(p => p.Id == employee.Id);
        if(index == -1)
            return;

        employees[index] = employee;
    }
}