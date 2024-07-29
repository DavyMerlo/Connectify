using Connectify.DataService.Data;
using Connectify.DataService.Repositories.Interfaces;
using Connectify.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Connectify.DataService.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Post>> All()
        {
            try
            {
                return await _dbSet.OrderBy(x => x.CreatedAt).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(PostRepository));
                throw;
            }
        }

        public override async Task<Post?> GetById(Guid id)
        {
            try
            {
                return await _context.Posts
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Get by Id", typeof(PostRepository));
                throw;
            }
        }

        public override async Task<bool> Update(Post post)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == post.Id);

                if (result == null)
                {
                    return false;
                }

                result.UpdatedAt = DateTime.UtcNow;
                result.Content = post.Content;
                result.Image_url = post.Image_url;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(PostRepository));
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
                _logger.LogError(ex, "{Repo} Delete function error", typeof(PostRepository));
                throw;
            }
        }

        public async Task<Post?> GetPostCommentsByPostIdAsync(Guid postId)
        {
            var result = await _dbSet
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == postId);

            return result;
        }

        public async Task<List<Post>> GetPostCommentsByAppUserIdAsync(Guid appUserId)
        {
            var result = await _dbSet
                .Where(x => x.AppUserId == appUserId.ToString())
                .Include(c => c.Comments)
                .ToListAsync();

            return result;
        }
    }
}
