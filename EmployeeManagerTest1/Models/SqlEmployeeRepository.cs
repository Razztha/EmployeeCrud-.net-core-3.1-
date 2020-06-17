using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagerTest1.Models
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private AppDbContext _context;

        public SqlEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Employee Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.Include(d => d.Department);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments;
        }

        public Department GetDepartment(int? id)
        {
            return _context.Departments.Find(id);
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.Include(d => d.Department).FirstOrDefault(e => e.Id == id);
        }

        public Employee EditEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();

            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }

            return employee;
        }
    }
}
