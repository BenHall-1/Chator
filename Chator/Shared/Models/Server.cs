using Chator.Shared.Models.Base;

namespace Chator.Shared.Models
{
    public class Server : BaseEntity
    {
        public Server() : base(EntityType.SERVER) { }

        public string Name { get; set; }

        public User Owner { get; set; }
    }
}
