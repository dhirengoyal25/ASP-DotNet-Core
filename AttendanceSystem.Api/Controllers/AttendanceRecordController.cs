using AttendanceSystem.Dto.Models;
using AttendanceSystem.Persistent.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceSystem.Api.Controllers
{
	[Route("api/attendance-records")]
	[ApiController]
	public class AttendanceRecordController : ControllerBase
	{
		private readonly IAttendanceRecordService _attendanceRecordService;

		public AttendanceRecordController(IAttendanceRecordService attendanceRecordService)
		{
			_attendanceRecordService = attendanceRecordService;
		}

		[HttpGet]
		public async Task<IEnumerable<AttendanceRecordDto>> Get()
		{
			return await _attendanceRecordService.GetAllAttendanceRecordsAsync();
		}

		[HttpGet("{employeeId}")]
		public async Task<IEnumerable<AttendanceRecordDto>> Get(long employeeId)
		{
			return await _attendanceRecordService.GetAttendanceRecordsAsync(employeeId);
		}

		[HttpPost]
		public async void Post([FromBody] AttendanceRecordDto attendanceRecordDto)
		{
			await _attendanceRecordService.AddAttendanceRecordAsync(attendanceRecordDto);
		}
	}
}
