using AttendanceSystem.Dto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceSystem.Persistent.Contracts
{
	public interface IEmployeeDetailsService
	{
		Task AddEmployeeAsync(EmployeeDetailsDto newEmployee);
		Task<EmployeeDetailsDto> GetEmployeeAsync(string username);
		Task<IEnumerable<EmployeeDetailsDto>> GetAllEmployeesAsync();
	}
}
