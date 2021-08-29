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
    public class UserService : IUserService
    {
        private UserManager<User, long> _userManager;

        private IMapper _mapper;

        public UserService(
            UserManager<User> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

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

        public Task<UserViewModel> GetByIdAsync(long id)
        {
            var user = await _userManager.FindByIdAsync(id);
        }
    }
}
