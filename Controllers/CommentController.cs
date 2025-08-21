using Microsoft.AspNetCore.Mvc;
using SMApi.DTO;
using SMApi.Interfaces;

namespace SMApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create(CommentCreateDTO commentCreateDTO)
        {
            return Ok(await commentService.createAsync(commentCreateDTO));
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            return Ok(await commentService.getAllAsync());
        }

        [HttpGet("getById")]
        public async Task<IActionResult> getById(int id, string type)
        {
            return Ok(await commentService.getByIdAsync(id,type));
        }

        [HttpPost("update")]
        public async Task<IActionResult> update(CommentUpdateDTO commentUpdateDTO)
        {
            return Ok(await commentService.updateAsync(commentUpdateDTO));  
        }

        [HttpPost("delete")]
        public async Task<IActionResult> delete(int commId)
        {
            var response=await commentService.deleteAsync(commId);
            return Ok(response);
        }
    }
}
