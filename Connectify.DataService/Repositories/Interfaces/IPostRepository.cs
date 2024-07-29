using Connectify.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.DataService.Repositories.Interfaces
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<Post?> GetPostCommentsByPostIdAsync(Guid postId);
        Task<List<Post>> GetPostCommentsByAppUserIdAsync(Guid appUserId);
    }
}
