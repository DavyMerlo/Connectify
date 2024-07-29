using Connectify.Entities.DbSet;
using Connectify.Entities.Dtos.Requests;
using Connectify.Entities.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.DataService.Services.Interfaces
{
    public interface ICommentService : IGenericService<UpdateCommentRequest, CreateCommentRequest, CommentResponse>
    {
        Task<IEnumerable<CommentResponse>> GetCommentsByAppUserId(Guid appUserId);
    }
}
