using FinalBackendProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalBackendProject.Repository
{
    public interface IEmployeeRepository
    {
        public List<EmployeeDTO> Get();
        public List<EmployeeDTO> GetById(int id);
        public bool Register([FromBody] Employee newEmployee);
        public bool Update(int id, [FromBody] Employee updateEmployee);
        public bool Delete(int id);
    }
}
