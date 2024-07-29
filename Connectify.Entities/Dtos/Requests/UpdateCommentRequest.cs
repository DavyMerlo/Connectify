using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.Entities.Dtos.Requests
{
    public class UpdateCommentRequest
    {
        public Guid CommentId { get; set; }
        public string? Content { get; set; }
    }
}
