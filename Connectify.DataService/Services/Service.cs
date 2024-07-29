using AutoMapper;
using Connectify.DataService.Repositories.Interfaces;
using Connectify.DataService.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Connectify.DataService.Services
{
    public class Service : IService
    {
        private readonly ILogger _logger;

        public IPostService PostService { get; }
        public ICommentService CommentService { get; }


        public Service(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("logs");

            PostService = new PostService(unitOfWork, mapper, _logger);
            CommentService = new CommentService(unitOfWork, mapper, _logger);
        }
    }
}
