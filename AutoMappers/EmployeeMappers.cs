using AutoMapper;
using FinalBackendProject.Models;

namespace FinalBackendProject.AutoMappers
{
    public class EmployeeMappers : Profile
    {
        public EmployeeMappers()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(src => src.Name, opt => opt.MapFrom(dest => $"{dest.FirstName} {dest.LastName}"));
        }
    }
}
