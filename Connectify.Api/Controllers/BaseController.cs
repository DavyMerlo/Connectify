using AutoMapper;
using Connectify.DataService.Repositories.Interfaces;
using Connectify.DataService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Connectify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IService _service;

        public BaseController(IService service)
        {
             _service = service;
        }
    }
}
