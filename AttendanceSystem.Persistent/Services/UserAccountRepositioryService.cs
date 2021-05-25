using AttendanceSystem.Dto.Models;
using AttendanceSystem.Persistent.Configurations;
using AttendanceSystem.Persistent.Contracts;
using AttendanceSystem.Persistent.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Persistent.Services
{
	public class UserAccountRepositioryService : IUserAccountRepositioryService
	{
		private readonly IRelationalDbContext _dbContext;

		public UserAccountRepositioryService(IRelationalDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddUserAsync(UserAccountDto newUser)
		{
			var exist = await _dbContext.Users.FindAsync(newUser.UserName);

			if (exist != null)
				throw new System.Exception("User already exist.");

			await _dbContext.Users.AddAsync(UserEntityMapper.ToEntity(newUser));
			await _dbContext.SaveChangesAsync();
		}

		public Task<UserAccountDto> AuthenticateUserAsync(string username, string password)
		{
			var userEntity = _dbContext.Users.FirstOrDefault(user => user.UserName == username && user.Password == password);

			if (userEntity == null)
				throw new System.Exception("Invalid username or password.");

			return Task.FromResult(UserEntityMapper.ToDto(userEntity));
		}

		public Task<IEnumerable<UserAccountDto>> GetAllUsersAsync()
		{
			return Task.FromResult(_dbContext.Users.Select(UserEntityMapper.ToDto));
		}

		public async Task<UserAccountDto> GetUserAsync(string username)
		{
			var userEntity = await _dbContext.Users.FindAsync(username);
			return UserEntityMapper.ToDto(userEntity);
		}
	}
}
