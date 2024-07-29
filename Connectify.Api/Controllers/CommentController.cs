using Connectify.DataService.Services.Interfaces;
using Connectify.Entities.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Connectify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController
    {
        public CommentController(IService service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var response = await _service.CommentService.GetAll();
            return Ok(response);
        }

        [HttpGet]
        [Route("{commentId:guid}")]
        public async Task<IActionResult> GetComment(Guid commentId)
        {
            var response = await _service.CommentService.GetById(commentId);
            return Ok(response);
        }

        [HttpPost()]
        public async Task<IActionResult> AddComment([FromBody] CreateCommentRequest comment)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _service.CommentService.Add(comment);
            return Ok(response);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentRequest comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.CommentService.Update(comment);
            return NoContent();
        }

        [HttpGet]
        [Route("{appUserId:guid}/comments")]
        public async Task<IActionResult> GetCommentsByAppUserId(Guid appUserId)
        {
            var comments = await _service.CommentService.GetCommentsByAppUserId(appUserId);
            return Ok(comments);
        }
    }
}
