using System.Security.Claims;
using System.Threading.Tasks;
using Chator.Core.Services.Interfaces;
using Chator.Server.Controllers.Base;
using Chator.Shared.Exceptions;
using Chator.Shared.ViewModels.APIResponse;
using Chator.Shared.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chator.Server.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Returns the <see cref="UserViewModel"/> object for the requester's account.
        /// </summary>
        /// <returns><see cref="UserViewModel"/> for the requester.</returns>
        [Authorize]
        [HttpGet("@me")]
        public async Task<ActionResult> GetAsync()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier);
            return new JsonResult(id);
        }

        /// <summary>
        /// Returns the <see cref="UserViewModel"/> for a given user ID.
        /// </summary>
        /// <param name="id">The ID of the User to pull data for.</param>
        /// <returns><see cref="UserViewModel"/> for ths given user ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync([FromRoute] long id) { return new AcceptedResult(); }

        /// <summary>
        /// Modify the requester's user account settings.
        /// </summary>
        /// <param name="createUserViewModel">The details to update.</param>
        /// <returns>An updated <see cref="UserViewModel"/>.</returns>
        [HttpPut("@me")]
        public async Task<ActionResult> GetAsync([FromBody] CreateUserViewModel createUserViewModel) { return new AcceptedResult(); }

        /// <summary>
        /// Returns a list of servers with minimal information.
        /// </summary>
        /// <returns>A list of <see cref="ServerViewModel"/>s depending for the requester.</returns>
        [HttpGet("@me/guilds")]
        public async Task<ActionResult> GetGuildsAsync()
        {
            return new AcceptedResult();
        }

        /// <summary>
        /// Leaves a server. Will return 204 on success.
        /// </summary>
        /// <param name="id">The snowflake of the server to leave.</param>
        /// <returns>204 if successful.</returns>
        [HttpDelete("@me/guilds/{id}")]
        public async Task<ActionResult> LeaveGuildAsync([FromRoute] long id) { return new AcceptedResult(); }

        /// <summary>
        /// Creates a user with the given information.
        /// </summary>
        /// <param name="createUserViewModel">The information to create the user based on.</param>
        /// <returns><see cref="UserViewModel"/> with the newly created user's information.</returns>
        [HttpPost("create")]
        public async Task<ActionResult> CreateAsync([FromBody] CreateUserViewModel createUserViewModel)
        {
            ActionResult returnValue;

            try
            {
                returnValue = new JsonResult(await _userService.CreateUserAsync(createUserViewModel));
            }
            catch (AccountCreationException ex)
            {
                returnValue = StatusCode(400, new ErrorResponse()
                {
                    Status = 400,
                    Error = $"Account Creation Failed: {string.Join(", ", ex.Error)}",
                });
            }

            return returnValue;
        }
    }
}
