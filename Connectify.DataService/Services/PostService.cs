using AutoMapper;
using Connectify.DataService.Repositories;
using Connectify.DataService.Repositories.Interfaces;
using Connectify.DataService.Services.Interfaces;
using Connectify.Entities.DbSet;
using Connectify.Entities.Dtos.Requests;
using Connectify.Entities.Dtos.Responses;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Connectify.DataService.Services
{
    public class PostService : GenericService<UpdatePostRequest, CreatePostRequest, PostResponse>, IPostService
    {
        public PostService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) 
            : base(unitOfWork, mapper, logger)
        {
        }

        public override async Task<IEnumerable<PostResponse>> GetAll()
        {
            try
            {
                var posts = await _unitOfWork.Posts.All();
                return _mapper.Map<IEnumerable<PostResponse>>(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Service} All function error", typeof(PostService));
                throw;
            }
        }

        public override async Task<PostResponse?> GetById(Guid id)
        {
            try
            {
                var post = await _unitOfWork.Posts.GetById(id);
                if (post == null)
                {
                    return null;
                }
                return _mapper.Map<PostResponse>(post);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Service} Get by Id", typeof(PostService));
                throw;
            }
        }

        public override async Task<PostResponse?> Add(CreatePostRequest request)
        {
            try
            {
                var addedPost = _mapper.Map<Post>(request);
                await _unitOfWork.Posts.Add(addedPost);
                await _unitOfWork.CompleteAsync();

                var post = await _unitOfWork.Posts.GetById(addedPost.Id);
                if (post == null)
                {
                    return null;
                }
                return _mapper.Map<PostResponse>(post);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Service} Add function error", typeof(PostService));
                throw;
            }
           
        }

        public override async Task Update(UpdatePostRequest request)
        {
            try
            {
                var updatedPost = _mapper.Map<Post>(request);
                await _unitOfWork.Posts.Update(updatedPost);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Service} Update function error", typeof(PostService));
                throw;
            }
          
        }

        public async Task<PostCommentResponse?> GetPostCommentsByPostId(Guid postId)
        {
            try
            {
                var postComments = await _unitOfWork.Posts.GetPostCommentsByPostIdAsync(postId);
                if (postComments == null)
                {
                    return null;
                }
                return _mapper.Map<PostCommentResponse>(postComments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Service} GetPostCommentsByPostId function error", typeof(PostService));
                throw;
            }
            
        }

        public async Task<IEnumerable<PostCommentResponse?>> GetPostCommentsByAppUserId(Guid appUserId)
        {
            try
            {
                var posts = await _unitOfWork.Posts.GetPostCommentsByAppUserIdAsync(appUserId);
                return _mapper.Map<IEnumerable<PostCommentResponse?>>(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Service} All function error", typeof(PostService));
                throw;
            }
        }
    }
}
