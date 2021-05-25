using AttendanceSystem.Dto.Types;

namespace AttendanceSystem.Dto.Models
{
	public class UserAccountDto
	{
		public LoginUserRoleType UserRoleType { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }
	}
}
