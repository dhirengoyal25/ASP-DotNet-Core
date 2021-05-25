using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace AttendanceSystem.Persistent.Models
{
	[Table("AttendanceReports")]
	public class AttendanceRecordEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		public long EmployeeId { get; set; }

		[ForeignKey(nameof(EmployeeId))]
		public EmployeeDetailsEntity Employee { get; set; }

		public DateTime InTime { get; set; }

		public DateTime OutTime { get; set; }

		public string Comment { get; set; }

		internal static Expression<Func<AttendanceRecordEntity, object>> GetKeys()
		{
			return entity => new { entity.Id };
		}
	}
}
