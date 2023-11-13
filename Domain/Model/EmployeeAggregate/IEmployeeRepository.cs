using WebAPI.Domain.DTOs;

namespace WebAPI.Domain.Model.EmployeeAggregate;

public interface IEmployeeRepository
{
    void Add(Employee employee);
    List<EmployeeDTO> GetAll(int pageNumber, int pageQuantity);
    Employee? GetById(int id);
}
