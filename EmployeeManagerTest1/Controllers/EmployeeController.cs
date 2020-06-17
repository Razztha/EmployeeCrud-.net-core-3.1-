using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EmployeeManagerTest1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagerTest1.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            return View(_employeeRepository.GetEmployees());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_employeeRepository.GetDepartments(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Telephone = model.Telephone,
                    Gender = model.Gender,
                    Department = _employeeRepository.GetDepartment(model.DepartmentId),
                    Agree = model.Agree
                };

                _employeeRepository.Add(employee);

                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(_employeeRepository.GetDepartments(), "Id", "Name");
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Departments = new SelectList(_employeeRepository.GetDepartments(), "Id", "Name");
            var employee = _employeeRepository.GetEmployee(id);

            EmployeeViewModel model = new EmployeeViewModel() 
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Telephone = employee.Telephone,
                Agree = employee.Agree,
                Gender = employee.Gender,
                DepartmentId = employee.Department.Id
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Email = model.Email,
                    Gender = model.Gender,
                    Agree = model.Agree,
                    Department = _employeeRepository.GetDepartment(model.DepartmentId),
                    Telephone = model.Telephone
                };

                _employeeRepository.EditEmployee(employee);
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(_employeeRepository.GetDepartments(), "Id", "Name");
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}