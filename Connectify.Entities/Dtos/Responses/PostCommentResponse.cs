using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.Entities.Dtos.Responses
{
    public class PostCommentResponse
    {
        public Guid PostId { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public List<CommentResponse> Comments { get; set; } = new List<CommentResponse>();
    }
}
