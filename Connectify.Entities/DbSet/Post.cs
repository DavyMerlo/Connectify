using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.Entities.DbSet
{
    public class Post : BaseEntity
    {
        [Required]
        [StringLength(1500)]
        public string Content { get; set; } = string.Empty;

        public string? Image_url { get; set; }

        [Required]
        public string? AppUserId { get; set; }

        public virtual AppUser? AppUser { get; set; }

        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
