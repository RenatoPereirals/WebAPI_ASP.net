using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.ViewModel;
using WebAPI.Domain.DTOs;
using WebAPI.Domain.Model.EmployeeAggregate;

namespace WebAPI.Controllers.V2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/employee")]
    [ApiVersion("2.0")]
    public class EmployeeController : ControllerBase
    {   
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeViewModel)
        {
            var filePath = Path.Combine("storage", employeeViewModel.Photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeViewModel.Photo.CopyTo(fileStream);
                
            var employee = new Employee(employeeViewModel.Name, employeeViewModel.Age, filePath);
            _employeeRepository.Add(employee);
            return Ok();
        }

        //[Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.GetById(id);

            if (employee == null) return BadRequest("Usuário não encontrado!");

            if (employee.photo != null)
            {
                var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

                return File(dataBytes, "image/jpeg");
            }

            return NotFound();
        }

        //[Authorize]
        [HttpGet]
        public IActionResult GetAll(int pageNumber, int pageQuantity)
        {
            _logger.Log(LogLevel.Error, "Teve um erro");

            var employee = _employeeRepository.GetAll(pageNumber, pageQuantity);

            _logger.LogInformation("Teste");

            return Ok(employee);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Search(int id)
        {
            //_logger.Log(LogLevel.Error, "Teve um erro");
            //_logger.LogInformation("Teste");

            var employee = _employeeRepository.GetById(id);

            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);

            return Ok(employeeDTO);
        }
    }
}
