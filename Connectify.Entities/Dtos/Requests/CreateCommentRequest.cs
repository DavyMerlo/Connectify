using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.Entities.Dtos.Requests
{
    public class CreateCommentRequest
    {
        public Guid PostId { get; set; }
        public string? Content { get; set; }
        public string? AppUserId { get; set; } = "e4114160-6dcf-46ac-a602-243cc7cc521a";
    }
}
