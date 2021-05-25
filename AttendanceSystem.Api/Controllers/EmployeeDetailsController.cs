using AttendanceSystem.Dto.Models;
using AttendanceSystem.Persistent.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceSystem.Api.Controllers
{
	[Route("api/employee-details")]
	[ApiController]
	public class EmployeeDetailsController : ControllerBase
	{
		private readonly IEmployeeDetailsService _employeeDetailsService;

		public EmployeeDetailsController(IEmployeeDetailsService employeeDetailsService)
		{
			_employeeDetailsService = employeeDetailsService;
		}

		[HttpGet]
		public async Task<IEnumerable<EmployeeDetailsDto>> Get()
		{
			return await _employeeDetailsService.GetAllEmployeesAsync();
		}

		[HttpGet("{username}")]
		public async Task<EmployeeDetailsDto> Get(string username)
		{
			return await _employeeDetailsService.GetEmployeeAsync(username);
		}

		[HttpPost]
		public async void Post([FromBody] EmployeeDetailsDto newEmployee)
		{
			await _employeeDetailsService.AddEmployeeAsync(newEmployee);
		}
	}
}
