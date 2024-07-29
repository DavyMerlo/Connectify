using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.Entities.Dtos.Requests
{
    public class UpdatePostRequest
    {
        public Guid PostId { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
    }
}
