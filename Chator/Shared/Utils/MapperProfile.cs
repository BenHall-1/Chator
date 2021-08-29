using AutoMapper;
using Chator.Shared.Models;
using Chator.Shared.ViewModels.User;

namespace Chator.Shared.Utils
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
