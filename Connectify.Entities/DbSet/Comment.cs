using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.Entities.DbSet
{
    public class Comment : BaseEntity
    {
        [Required]
        [StringLength(500)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public string? AppUserId { get; set; }

        public virtual AppUser? AppUser { get; set; }

        public Guid PostId { get; set; }
        public virtual Post? Post { get; set; }
    }
}
