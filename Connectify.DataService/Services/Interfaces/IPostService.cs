using Connectify.DataService.Repositories.Interfaces;
using Connectify.Entities.DbSet;
using Connectify.Entities.Dtos.Requests;
using Connectify.Entities.Dtos.Responses;

namespace Connectify.DataService.Services.Interfaces
{
    public interface IPostService : IGenericService<UpdatePostRequest, CreatePostRequest, PostResponse>
    {
        Task<PostCommentResponse?> GetPostCommentsByPostId(Guid postId);
        Task<IEnumerable<PostCommentResponse?>> GetPostCommentsByAppUserId(Guid appUserId);
    }
}
