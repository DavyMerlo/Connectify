using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.Entities.DbSet
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDay { get; set; }

        [Required]
        public char Gender { get; set; }

        public virtual List<Post> Posts { get; set; } = new List<Post>();
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
