using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chator.Core.Services.Interfaces;
using Chator.Shared.Exceptions;
using Chator.Shared.Models;
using Chator.Shared.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Chator.Core.Services
{
    /// <summary>
    /// The User Service to handle all User actions.
    /// </summary>
    public class UserService : IUserService
    {
        private UserManager<User> _userManager;

        private IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userManager">The user manager to get the information from.</param>
        /// <param name="mapper">The AutoMapper to use for passing through ViewModels.</param>
        public UserService(
            UserManager<User> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<UserViewModel> CreateUserAsync(CreateUserViewModel viewModel)
        {
            var checkUsernameDiscrim = await _userManager.Users.FirstOrDefaultAsync(user => user.UserName == viewModel.Username && user.Discriminator == 0001);

            if (checkUsernameDiscrim != null)
            {
                throw new AccountCreationException("Username & Discriminator already exists");
            }

            var userResult = await _userManager.CreateAsync(
                new User()
                {
                    Email = viewModel.Email,
                    UserName = viewModel.Username,
                    Discriminator = 0001,
                }, viewModel.Password);

            if (!userResult.Succeeded)
            {
                throw new AccountCreationException(userResult.Errors.Select(e => e.Description).ToList());
            }

            return _mapper.Map<UserViewModel>(await _userManager.FindByEmailAsync(viewModel.Email));
        }
    }
}
