using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagerTest1.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee Add(Employee employee);

        IEnumerable<Department> GetDepartments();

        Department GetDepartment(int? id);

        Employee GetEmployee(int id);

        Employee EditEmployee(Employee employee);

        Employee DeleteEmployee(int id);
    }
}
