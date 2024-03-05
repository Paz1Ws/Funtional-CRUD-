using AutoMapper;
using FinalBackendProject.Context;
using FinalBackendProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query;
using FinalBackendProject.Migrations;

namespace FinalBackendProject.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _employee;

        private readonly IMapper _employeMapper;
        public EmployeeRepository(EmployeeContext employee, IMapper employeeMappers)
        {
            _employee = employee;
            _employeMapper = employeeMappers;
        }

        public List<EmployeeDTO> Get()
        {
            var employees =  _employee.Employees.ToList();
            var employeeDtos = _employeMapper.Map<List<EmployeeDTO>>(employees).ToList();
            if (employeeDtos.Count()!=0)
            {
                return employeeDtos;
            }
            return null;

        }

        public List<EmployeeDTO> GetById(int id)
        {
            var Employee = _employee.Employees.Where(x => x.EmployeeID == id).ToList();
            var getEmployee = _employeMapper.Map<List<EmployeeDTO>>(Employee).ToList();
            return getEmployee;
        }
        public bool Register( [FromBody] Employee newEmployee)
        {
            var employee = _employee.Employees.FirstOrDefault(x => x.EmployeeID == newEmployee.EmployeeID);
            if (employee == null)
            {
                _employee.Add(newEmployee);
                _employee.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(int id, [FromBody] Employee updateEmployee )
        {
           var employee = _employee.Employees.FirstOrDefault(x => x.EmployeeID == id);
            if (employee != null)
            {
                employee.EmployeeID = updateEmployee.EmployeeID;
                employee.Salary = updateEmployee.Salary;
                employee.Adress = updateEmployee.Adress;
                employee.Charge = updateEmployee.Charge;
                employee.Name = updateEmployee.Name;
                _employee.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var removedEmployee = _employee.Employees.FirstOrDefault(e => e.EmployeeID == id);
            if (removedEmployee != null)
            {
                _employee.Remove(removedEmployee);
                _employee.SaveChanges();
                return true;
            }
            return false;
        }
        
    }
}
