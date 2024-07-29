using Connectify.DataService.Data;
using Connectify.DataService.Repositories.Interfaces;
using Connectify.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Connectify.DataService.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Comment>> All()
        {
            try
            {
                return await _dbSet.OrderBy(x => x.CreatedAt).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Get All function error", typeof(CommentRepository));
                throw;
            }
        }

        public override async Task<Comment?> GetById(Guid id)
        {
            try
            {
                return await _context.Comments
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Get by Id", typeof(CommentRepository));
                throw;
            }
        }

        public override async Task<bool> Update(Comment comment)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == comment.Id);

                if (result == null)
                {
                    return false;
                }

                result.UpdatedAt = DateTime.UtcNow;
                result.Content = comment.Content;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(CommentRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

                if (result == null)
                {
                    return false;
                }

                result.DeletedAt = DateTime.UtcNow;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(CommentRepository));
                throw;
            }
        }

        public async Task<IEnumerable<Comment?>> GetCommentsAsync(Guid postId)
        {
            try
            {
                return await _context.Comments
                           .Where(c => c.PostId == postId)
                           .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetComments function error", typeof(CommentRepository));
                throw;
            }
        }

        public async Task<IEnumerable<Comment?>> GetCommentsByAppUserIdAsync(Guid appUserId)
        {
            try
            {
                return await _context.Comments
                    .Where(c => c.AppUserId == appUserId.ToString())
                    .ToListAsync(); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetCommentsByAppUserId function error", typeof(CommentRepository));
                throw;
            }
        }
    }
}
