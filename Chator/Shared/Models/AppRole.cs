using IdGen;
using Microsoft.AspNetCore.Identity;

namespace Chator.Shared.Models
{
    public class AppRole : IdentityRole<long>
    {
        public AppRole()
        {
            Id = new IdGenerator(1000).CreateId();
        }
    }
}
