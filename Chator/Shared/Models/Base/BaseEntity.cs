using IdGen;
using System.ComponentModel.DataAnnotations;

namespace Chator.Shared.Models.Base
{
    public class BaseEntity
    {
        public BaseEntity(EntityType type)
        {
            Id = new IdGenerator((int) type).CreateId();
        }

        [Key]
        public long Id { get; set; }
    }
}
