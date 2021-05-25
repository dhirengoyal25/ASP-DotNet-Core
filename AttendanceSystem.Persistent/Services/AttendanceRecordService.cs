using AttendanceSystem.Dto.Models;
using AttendanceSystem.Persistent.Configurations;
using AttendanceSystem.Persistent.Contracts;
using AttendanceSystem.Persistent.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Persistent.Services
{
	public class AttendanceRecordService : IAttendanceRecordService
	{
		private readonly IRelationalDbContext _dbContext;

		public AttendanceRecordService(IRelationalDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAttendanceRecordAsync(AttendanceRecordDto newAttendanceRecord)
		{
			var employeeEntity = await _dbContext.Employees.FindAsync(newAttendanceRecord.EmployeeId);

			if (employeeEntity == null)
				throw new System.Exception($"Employee doesn't exist with Id = {newAttendanceRecord.EmployeeId}");

			var attendanceRecordEntity = AttendanceRecordEntityMapper.ToEntity(newAttendanceRecord);
			attendanceRecordEntity.Employee = employeeEntity;

			await _dbContext.AttendanceRecords.AddAsync(attendanceRecordEntity);
			await _dbContext.SaveChangesAsync();
		}

		public Task<IEnumerable<AttendanceRecordDto>> GetAllAttendanceRecordsAsync()
		{
			return Task.FromResult(_dbContext.AttendanceRecords.Select(AttendanceRecordEntityMapper.ToDto));
		}

		public Task<IEnumerable<AttendanceRecordDto>> GetAttendanceRecordsAsync(long employeeId)
		{
			var attendanceRecords = _dbContext.AttendanceRecords.Where(emp => emp.EmployeeId == employeeId).Select(AttendanceRecordEntityMapper.ToDto);
			return Task.FromResult(attendanceRecords);
		}
	}
}
