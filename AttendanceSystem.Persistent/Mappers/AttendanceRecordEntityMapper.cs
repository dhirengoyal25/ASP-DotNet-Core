using AttendanceSystem.Dto.Models;
using AttendanceSystem.Persistent.Models;

namespace AttendanceSystem.Persistent.Mappers
{
	internal static class AttendanceRecordEntityMapper
	{
		internal static AttendanceRecordDto ToDto(AttendanceRecordEntity attendanceRecordEntity)
		{
			return new AttendanceRecordDto {
				EmployeeId = attendanceRecordEntity.EmployeeId,
				InTime = attendanceRecordEntity.InTime,
				OutTime = attendanceRecordEntity.OutTime,
				Comment = attendanceRecordEntity.Comment,
				Id = attendanceRecordEntity.Id
			};
		}

		internal static AttendanceRecordEntity ToEntity(AttendanceRecordDto attendanceRecordDto)
		{
			return new AttendanceRecordEntity {
				EmployeeId = attendanceRecordDto.EmployeeId,
				InTime = attendanceRecordDto.InTime,
				OutTime = attendanceRecordDto.OutTime,
				Comment = attendanceRecordDto.Comment,
				Id = attendanceRecordDto.Id
			};
		}
	}
}
