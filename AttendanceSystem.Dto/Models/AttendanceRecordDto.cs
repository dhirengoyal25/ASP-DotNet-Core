using System;

namespace AttendanceSystem.Dto.Models
{
	public class AttendanceRecordDto
	{
		public long Id { get; set; }

		public long EmployeeId { get; set; }

		public DateTime InTime { get; set; }

		public DateTime OutTime { get; set; }

		public string Comment { get; set; }
	}
}
