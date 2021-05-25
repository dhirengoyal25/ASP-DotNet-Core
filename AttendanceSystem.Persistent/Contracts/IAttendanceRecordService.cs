using AttendanceSystem.Dto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceSystem.Persistent.Contracts
{
	public interface IAttendanceRecordService
	{
		Task AddAttendanceRecordAsync(AttendanceRecordDto newAttendanceRecord);
		Task<IEnumerable<AttendanceRecordDto>> GetAttendanceRecordsAsync(long employeeId);
		Task<IEnumerable<AttendanceRecordDto>> GetAllAttendanceRecordsAsync();
	}
}
