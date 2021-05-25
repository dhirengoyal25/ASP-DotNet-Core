using AttendanceSystem.Dto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceSystem.Persistent.Contracts
{
	public interface IUserAccountRepositioryService
	{
		Task AddUserAsync(UserAccountDto newUser);
		Task<UserAccountDto> AuthenticateUserAsync(string username, string password);
		Task<UserAccountDto> GetUserAsync(string username);
		Task<IEnumerable<UserAccountDto>> GetAllUsersAsync();
	}
}
