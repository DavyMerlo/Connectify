using AutoMapper;
using Connectify.DataService.Repositories.Interfaces;
using Connectify.DataService.Services.Interfaces;
using Connectify.Entities.DbSet;
using Connectify.Entities.Dtos.Requests;
using Connectify.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Connectify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseController
    {
        public PostController(IService service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            var response = await _service.PostService.GetAll();
            return Ok(response);
        }

        [HttpGet]
        [Route("{postId:guid}")]
        public async Task<IActionResult> GetPost(Guid postId)
        {
            var response = await _service.PostService.GetById(postId);
            return Ok(response);
        }


        [HttpPost()]
        public async Task<IActionResult> AddPost([FromBody] CreatePostRequest post)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _service.PostService.Add(post);
            return CreatedAtAction(nameof(GetPost), new { postId = response?.PostId }, response);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostRequest post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.PostService.Update(post);
            return NoContent();
        }

        [HttpGet]
        [Route("{postId:guid}/comments")]
        public async Task<IActionResult> GetPostCommentsByPostId(Guid postId)
        {
            var postComments = await _service.PostService.GetPostCommentsByPostId(postId);
            return Ok(postComments);
        }

        [HttpGet]
        [Route("{appUserId:guid}/posts")]
        public async Task<IActionResult> GetPostCommentsByAppUserId(Guid appUserId)
        {
            var postComments = await _service.PostService.GetPostCommentsByAppUserId(appUserId);
            return Ok(postComments);
            //Test
        }
    }
}
