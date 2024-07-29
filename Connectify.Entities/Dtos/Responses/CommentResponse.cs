using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.Entities.Dtos.Responses
{
    public class CommentResponse
    {
        public Guid CommentId { get; set; }
        public string? Content { get; set; }
    }
}
