using AttendanceSystem.Dto.Models;
using AttendanceSystem.Persistent.Models;

namespace AttendanceSystem.Persistent.Mappers
{
	internal static class EmployeeDetailsEntityMapper
	{
		internal static EmployeeDetailsDto ToDto(EmployeeDetailsEntity employeeDetailsEntity)
		{
			return new EmployeeDetailsDto {
				Name = employeeDetailsEntity.Name,
				Id = employeeDetailsEntity.Id,
				Age = employeeDetailsEntity.Age,
				UserName = employeeDetailsEntity.UserName
			};
		}

		internal static EmployeeDetailsEntity ToEntity(EmployeeDetailsDto employeeDto)
		{
			return new EmployeeDetailsEntity {
				Name = employeeDto.Name,
				Id = employeeDto.Id,
				Age = employeeDto.Age,
				UserName = employeeDto.UserName
			};
		}
	}
}
