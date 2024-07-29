using AutoMapper;
using Connectify.DataService.Repositories.Interfaces;
using Connectify.DataService.Services.Interfaces;
using Connectify.Entities.DbSet;
using Connectify.Entities.Dtos.Requests;
using Connectify.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Connectify.DataService.Services
{
    public class CommentService : GenericService<UpdateCommentRequest, CreateCommentRequest, CommentResponse>, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) 
            : base(unitOfWork, mapper, logger)
        {
        }

        public override async Task<IEnumerable<CommentResponse>> GetAll()
        {
            try
            {
                var posts = await _unitOfWork.Comments.All();
                return _mapper.Map<IEnumerable<CommentResponse>>(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Service} All function error", typeof(CommentService));
                throw;
            }
        }

        public override async Task<CommentResponse?> GetById(Guid id)
        {
            try
            {
                var comment = await _unitOfWork.Comments.GetById(id);
                if (comment == null)
                {
                    return null;
                }
                return _mapper.Map<CommentResponse>(comment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Service} Get by Id", typeof(CommentService));
                throw;
            }
        }

        public override async Task<CommentResponse?> Add(CreateCommentRequest request)
        {
            try
            {
                var addedComment = _mapper.Map<Comment>(request);
                await _unitOfWork.Comments.Add(addedComment);
                await _unitOfWork.CompleteAsync();

                var comment = await _unitOfWork.Comments.GetById(addedComment.Id);
                if (comment == null)
                {
                    return null;
                }
                return _mapper.Map<CommentResponse?>(comment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Service} Add function error", typeof(CommentService));
                throw;
            }
        }

        public override async Task Update(UpdateCommentRequest request)
        {
            try
            {
                var updatedComment = _mapper.Map<Comment>(request);
                await _unitOfWork.Comments.Update(updatedComment);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Service} Update function error", typeof(CommentService));
                throw;
            }
        }

        public async Task<IEnumerable<CommentResponse>> GetCommentsByAppUserId(Guid appUserId)
        {
            try
            {
                var comments = await _unitOfWork.Comments.GetCommentsByAppUserIdAsync(appUserId);
                return _mapper.Map<IEnumerable<CommentResponse>>(comments); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Service} All function error", typeof(CommentService));
                throw;
            }
        }
    }
}
