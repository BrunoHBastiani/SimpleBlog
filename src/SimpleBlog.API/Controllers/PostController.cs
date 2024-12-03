using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.API.Extensions;
using SimpleBlog.Application.DTOs.Posts.Requests;
using SimpleBlog.Application.DTOs.Posts.Responses;
using SimpleBlog.Application.Exceptions;
using SimpleBlog.Application.Interfaces;
using System.Net;

[Route("api/posts")]
[ApiController]
[Authorize]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePostRequest request)
    {
        try
        {
            var user = this.GetLoggedUser();
            Guid postId = await _postService.CreateAsync(request, user.Id);
            return Created("api/posts", postId);
        }
        catch (HttpException e)
        {
            return StatusCode(e.StatusCode, e.Message);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro durante o processamento. Tente novamente em alguns minutos");
        }
    }

    [HttpPut("{postId}")]
    [ProducesResponseType(typeof(UpdatePostResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdatePostRequest request, Guid postId)
    {
        try
        {
            var user = this.GetLoggedUser();
            UpdatePostResponse response = await _postService.UpdateAsync(request, postId, user.Id);
            return Ok(response);
        }
        catch (HttpException e)
        {
            return StatusCode(e.StatusCode, e.Message);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro durante o processamento. Tente novamente em alguns minutos");
        }
    }

    [HttpGet("{postId}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(GetPostByIdResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetByIdAsync(Guid postId)
    {
        try
        {
            GetPostByIdResponse response = await _postService.GetByIdAsync(postId);
            return Ok(response);
        }
        catch (HttpException e)
        {
            return StatusCode(e.StatusCode, e.Message);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro durante o processamento. Tente novamente em alguns minutos");
        }
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(GetPostsResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromQuery] GetPostsRequest request)
    {
        try
        {
            GetPostsResponse response = await _postService.GetAsync(request);
            return Ok(response);
        }
        catch (HttpException e)
        {
            return StatusCode(e.StatusCode, e.Message);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro durante o processamento. Tente novamente em alguns minutos");
        }
    }

    [HttpDelete("{postId}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> DeleteAsync(Guid postId)
    {
        try
        {
            var user = this.GetLoggedUser();
            await _postService.DeleteAsync(postId, user.Id);
            return NoContent();
        }
        catch (HttpException e)
        {
            return StatusCode(e.StatusCode, e.Message);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro durante o processamento. Tente novamente em alguns minutos");
        }
    }
}
