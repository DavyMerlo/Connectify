using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.DataService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }
        ICommentRepository Comments { get; }

        Task<bool> CompleteAsync();
    }
}
