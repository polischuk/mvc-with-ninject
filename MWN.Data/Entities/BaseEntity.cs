using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWN.Data.Entities
{
    public abstract class BaseEntity
    {
        private DateTime _addedDate;
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime AddedDate
        {
            get { return DateTime.SpecifyKind(_addedDate, DateTimeKind.Utc); }
            private set { _addedDate = value; }
        }
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            AddedDate = DateTime.UtcNow;
        }
    }
}
