using System.Threading.Tasks;
using Chator.Shared.ViewModels.User;

namespace Chator.Core.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserViewModel> CreateUserAsync(CreateUserViewModel viewModel);

        public Task<UserViewModel> GetByIdAsync(long id);
    }
}
