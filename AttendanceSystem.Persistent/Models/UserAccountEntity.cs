using AttendanceSystem.Dto.Types;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace AttendanceSystem.Persistent.Models
{
	[Table("Users")]
	public class UserAccountEntity
	{
		[Column(Order = 0)]
		public LoginUserRoleType UserRoleType { get; set; }

		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string UserName { get; set; }

		public string Password { get; set; }

		internal static Expression<Func<UserAccountEntity, object>> GetKeys()
		{
			return entity => new { entity.UserName };
		}
	}
}
