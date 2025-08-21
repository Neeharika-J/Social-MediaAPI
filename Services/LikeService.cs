using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SMApi.dbcontext;
using SMApi.DTO;
using SMApi.Interfaces;
using SMApi.Models;

namespace SMApi.Services
{
    public class LikeService: ILikeService
    {
        private readonly ApplicationDBContext dbContext;
        private readonly IMapper mapper;
        public LikeService(ApplicationDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<string> create(LikeCreateDTO likeCreateDTO)
        {
            if (likeCreateDTO.postId!=0)
            {
                var like = mapper.Map<LikePosts>(likeCreateDTO);
                like.createdAt = DateTime.Now;
                dbContext.LikePosts.Add(like);
                await dbContext.SaveChangesAsync();
            }
            if (likeCreateDTO.commentId != 0)
            {
                var like = mapper.Map<LikeComments>(likeCreateDTO);
                like.createdAt = DateTime.Now;
                dbContext.LikeComments.Add(like);
                await dbContext.SaveChangesAsync();
            }
            return (likeCreateDTO.postId != default) ? "Post Liked" : "Comment Liked";
        }

        public async Task<string> remove(LikeRemoveDTO likeRemoveDTO)
        {
            if (likeRemoveDTO.likePostId != default)
            {
                var like = await dbContext.LikePosts.FirstOrDefaultAsync(p=>p.likePostId==likeRemoveDTO.likePostId && p.userId==likeRemoveDTO.userId);
                dbContext.LikePosts.Remove(like);
                await dbContext.SaveChangesAsync();
                return "post unliked.";
            }
            if(likeRemoveDTO.likeCommentId != default)
            {
                var like = await dbContext.LikeComments.FirstOrDefaultAsync(c => c.likeCommentId == likeRemoveDTO.likeCommentId && c.userId==likeRemoveDTO.userId);
                dbContext.LikeComments.Remove(like);
                await dbContext.SaveChangesAsync();
                return "comment unliked.";
            }
            return "error";
        }

        public async Task<int> getLikesCountOnPost(int postId)
        {
            return await dbContext.LikePosts.Where(p=>p.postId==postId).CountAsync();
        }

        public async Task<int> getLikesCountOnComment(int commentId)
        {
            return await dbContext.LikeComments.Where(c=>c.commentId==commentId).CountAsync();
        }


    }
}
