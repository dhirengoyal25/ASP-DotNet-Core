using AttendanceSystem.Dto.Models;
using AttendanceSystem.Persistent.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceSystem.Api.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UserAccountController : ControllerBase
	{
		private readonly IUserAccountRepositioryService _userAccountRepositioryService;

		public UserAccountController(IUserAccountRepositioryService userAccountRepositioryService)
		{
			_userAccountRepositioryService = userAccountRepositioryService;
		}

		[HttpGet]
		public async Task<IEnumerable<UserAccountDto>> Get()
		{
			return await _userAccountRepositioryService.GetAllUsersAsync();
		}

		[HttpGet]
		[Route("{username}")]
		public async Task<UserAccountDto> Get(string username)
		{
			return await _userAccountRepositioryService.GetUserAsync(username);
		}

		[HttpPost]
		public async Task<string> Add([FromBody] UserAccountDto userAccount)
		{
			await _userAccountRepositioryService.AddUserAsync(userAccount);
			return "Success";
		}
	}
}