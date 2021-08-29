using System.ComponentModel.DataAnnotations;
using IdGen;

namespace Chator.Shared.Models.Base
{
    /// <summary>
    /// The Base Entity.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class.
        /// </summary>
        /// <param name="type">The type of entity.</param>
        public BaseEntity(EntityType type)
        {
            Id = new IdGenerator((int)type).CreateId();
        }

        /// <summary>
        /// Gets or sets the ID of the Entity (Now defaults to longs).
        /// </summary>
        [Key]
        public long Id { get; set; }
    }
}
