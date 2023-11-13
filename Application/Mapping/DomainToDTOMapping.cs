using AutoMapper;
using WebAPI.Domain.DTOs;
using WebAPI.Domain.Model.EmployeeAggregate;

namespace WebAPI.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => 
                    dest.NameEmployee, m => 
                    m.MapFrom(orig => orig.name));
        }
    }
}
