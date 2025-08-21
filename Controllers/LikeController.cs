using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SMApi.DTO;
using SMApi.Interfaces;

namespace SMApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService likeService;
        public LikeController(ILikeService likeService)
        {
            this.likeService = likeService;
        }

        [HttpGet("count_posts")]
        public async Task<IActionResult> getLikesOnPost(int postId)
        {
            return Ok(await likeService.getLikesCountOnPost(postId));
        }

        [HttpGet("count_comments")]
        public async Task<IActionResult> getLikesOnComment(int commentId)
        {
            return Ok(await likeService.getLikesCountOnComment(commentId));
        }

        [HttpPost("like")]
        public async Task<IActionResult> like(LikeCreateDTO likeCreateDTO)
        {
            var response = await likeService.create(likeCreateDTO);
            return Ok(response);
        }

        [HttpPost("unlike")]
        public async Task<IActionResult> remove(LikeRemoveDTO likeRemoveDTO) 
        {
            return Ok(await likeService.remove(likeRemoveDTO));
        }

    }
}
