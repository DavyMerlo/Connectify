using AutoMapper;
using Connectify.DataService.Repositories.Interfaces;
using Connectify.DataService.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.DataService.Services
{
    public class GenericService<UpdateRequest, CreateRequest, Response> : IGenericService<UpdateRequest, CreateRequest, Response> 
        where UpdateRequest : class?
        where CreateRequest : class?
        where Response : class? 
    {
        protected IUnitOfWork _unitOfWork;
        protected IMapper  _mapper;
        protected ILogger _logger;

        public GenericService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public virtual async Task<IEnumerable<Response>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response?> Add(CreateRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task Update(UpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
