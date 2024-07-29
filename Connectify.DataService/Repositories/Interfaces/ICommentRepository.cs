using Connectify.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.DataService.Repositories.Interfaces
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<IEnumerable<Comment?>> GetCommentsAsync(Guid postId);
        Task<IEnumerable<Comment?>> GetCommentsByAppUserIdAsync(Guid appUserId);
    }
}
