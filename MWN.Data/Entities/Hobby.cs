using System.Collections.Generic;

namespace MWN.Data.Entities
{
    public class Hobby : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<ApplicationUser> Users{ get; set; }
    }
}