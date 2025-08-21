using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMApi.dbcontext;
using SMApi.DTO;
using SMApi.Interfaces;
using SMApi.Services;

namespace SMApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly ApplicationDBContext dbContext;
        public PostController(IPostService postService, ApplicationDBContext dbContext)
        {
            this.postService = postService;
            this.dbContext = dbContext;
        }

        [HttpPost("createPost")]
        public async Task<IActionResult> createPost(PostCreateDTO postCreateDTO)
        {
            var response = await postService.createPostAsync(postCreateDTO);
            return Ok(response);
        }

        [HttpGet("getAllPosts")]
        public async Task<IActionResult> getAllPosts()
        {
            var response = await dbContext.Post.ToListAsync();
            return Ok(response);
        }

        [HttpGet("getPostById")]
        public async Task<IActionResult> getPostById(int userId)
        {
            var response = await postService.getPostByIdAsync(userId);
            return Ok(response);
        }


        [HttpPost("updatePost")]
        public async Task<IActionResult> updatePost(postUpdateDTO postUpdateDTO)
        {
            var response = await postService.updatePostAsync(postUpdateDTO);
            return Ok(response);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> deletePost(int postid)
        {
            return Ok(await postService.deleteAsync(postid));
        }
    }
}
