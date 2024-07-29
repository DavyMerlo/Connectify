using Connectify.Entities.Dtos.Requests;
using Connectify.Entities.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.DataService.Services.Interfaces
{
    public interface IGenericService<UpdateRequest, CreateRequest, Response> 
        where UpdateRequest : class? 
        where CreateRequest : class? 
        where Response : class?
    {
        Task<IEnumerable<Response>> GetAll();
        Task<Response?> GetById(Guid id);
        Task<Response?> Add(CreateRequest request);
        Task Update(UpdateRequest request);
    }
}
