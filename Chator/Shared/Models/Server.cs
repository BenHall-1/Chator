using Chator.Shared.Models.Base;

namespace Chator.Shared.Models
{
    /// <summary>
    /// The main Server model.
    /// </summary>
    public class Server : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        public Server()
            : base(EntityType.SERVER)
        {
        }

        /// <summary>
        /// Gets or sets the name of the <see cref="Server"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the owner of the <see cref="Server"/>.
        /// </summary>
        public User Owner { get; set; }
    }
}
