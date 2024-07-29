using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.DataService.Services.Interfaces
{
    public interface IService
    {
        IPostService PostService { get; }
        ICommentService CommentService { get; }
    }
}
