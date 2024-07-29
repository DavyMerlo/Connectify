using Connectify.DataService.Data;
using Connectify.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public IPostRepository Posts { get; }
        public ICommentRepository Comments { get; }

        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Posts = new PostRepository(_context, _logger);
            Comments = new CommentRepository(_context, _logger);
        }

        public async Task<bool> CompleteAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
;       }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
