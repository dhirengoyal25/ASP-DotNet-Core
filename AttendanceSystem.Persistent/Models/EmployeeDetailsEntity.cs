using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace AttendanceSystem.Persistent.Models
{
	[Table("Employees")]

	public class EmployeeDetailsEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		public string Name { get; set; }

		public string Age { get; set; }


		public string UserName { get; set; }

		[ForeignKey(nameof(UserName))]
		public UserAccountEntity UserAccount { get; set; }

		internal static Expression<Func<EmployeeDetailsEntity, object>> GetKeys()
		{
			return entity => new { entity.Id };
		}
	}
}