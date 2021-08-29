using System.Threading.Tasks;
using Chator.Shared.ViewModels.User;

namespace Chator.Core.Services.Interfaces
{
    /// <summary>
    /// Interface for the <see cref="UserService"/>.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates a <see cref="User"/> from the given view model.
        /// </summary>
        /// <param name="viewModel">The ViewModel to create the <see cref="User"/> from.</param>
        /// <returns>A <see cref="UserViewModel"/> for the given <see cref="User"/> once created.</returns>
        public Task<UserViewModel> CreateUserAsync(CreateUserViewModel viewModel);
    }
}
