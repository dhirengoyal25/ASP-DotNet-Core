using AttendanceSystem.Dto.Models;
using AttendanceSystem.Persistent.Configurations;
using AttendanceSystem.Persistent.Contracts;
using AttendanceSystem.Persistent.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Persistent.Services
{
	public class EmployeeDetailsService : IEmployeeDetailsService
	{
		private readonly IRelationalDbContext _dbContext;

		public EmployeeDetailsService(IRelationalDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddEmployeeAsync(EmployeeDetailsDto newEmployee)
		{
			var exist = _dbContext.Employees.FirstOrDefault(emp => emp.UserName == newEmployee.UserName);

			if (exist != null)
				throw new System.Exception("Employee already exist.");

			var userEntity = await _dbContext.Users.FindAsync(newEmployee.UserName);

			if (userEntity == null)
				throw new System.Exception("User doesnot exist.. Kindly create user first then add employee details");

			var newEmployeeEntity = EmployeeDetailsEntityMapper.ToEntity(newEmployee);
			newEmployeeEntity.UserAccount = userEntity;

			await _dbContext.Employees.AddAsync(newEmployeeEntity);
			await _dbContext.SaveChangesAsync();
		}

		public Task<IEnumerable<EmployeeDetailsDto>> GetAllEmployeesAsync()
		{
			return Task.FromResult(_dbContext.Employees.Select(EmployeeDetailsEntityMapper.ToDto));
		}

		public Task<EmployeeDetailsDto> GetEmployeeAsync(string username)
		{
			var employeeEntity = _dbContext.Employees.FirstOrDefault(emp => emp.UserName == username);

			return Task.FromResult(EmployeeDetailsEntityMapper.ToDto(employeeEntity));
		}
	}
}
