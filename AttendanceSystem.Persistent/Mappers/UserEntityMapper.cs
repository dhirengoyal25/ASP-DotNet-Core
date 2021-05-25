using AttendanceSystem.Dto.Models;
using AttendanceSystem.Persistent.Models;

namespace AttendanceSystem.Persistent.Mappers
{
	internal static class UserEntityMapper
	{
		internal static UserAccountDto ToDto(UserAccountEntity userAccountEntity)
		{
			return new UserAccountDto {
				UserName = userAccountEntity.UserName,
				Password = userAccountEntity.Password,
				UserRoleType = userAccountEntity.UserRoleType
			};
		}

		internal static UserAccountEntity ToEntity(UserAccountDto userAccountDto)
		{
			return new UserAccountEntity {
				UserName = userAccountDto.UserName,
				Password = userAccountDto.Password,
				UserRoleType = userAccountDto.UserRoleType
			};
		}
	}
}
