using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMApi.dbcontext;
using SMApi.DTO;
using SMApi.Interfaces;
using SMApi.Models;

namespace SMApi.Services
{
    public class CommentService:ICommentService
    {
        private readonly ApplicationDBContext dBContext;
        private readonly IMapper mapper;

        public CommentService(ApplicationDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<CommentReadDTO> createAsync(CommentCreateDTO commentCreateDTO)
        {
            var comment=mapper.Map<Comments>(commentCreateDTO);
            if (comment != null)
            {
                comment.createdAt = DateTime.Now;
                await dBContext.Comment.AddAsync(comment);
                await dBContext.SaveChangesAsync();
            }
            return mapper.Map<CommentReadDTO>(comment);
        }

        public async Task<IEnumerable<CommentReadDTO>> getByIdAsync(int id,string type)
        {
            IEnumerable<Comments> comment = null;
            if (type == "post")
            {
                comment=await dBContext.Comment.Where(c => c.postId == id).ToListAsync();
            }
            if (type == "user")
            {
                comment = await dBContext.Comment.Where(c => c.userId == id).ToListAsync();
            }
            if (type == "comment")
            {
                comment = await dBContext.Comment.Where(c => c.commentId == id).ToListAsync();
            }
            
            return mapper.Map<IEnumerable<CommentReadDTO>>(comment);
        }

        public async Task<CommentReadDTO> updateAsync(CommentUpdateDTO commentUpdateDTO)
        {
            var comment = await dBContext.Comment.FirstOrDefaultAsync(c => c.commentId == commentUpdateDTO.commentId);
            comment.commentText=commentUpdateDTO.commentText;
            return mapper.Map<CommentReadDTO>(comment);
        }

        public async Task<IEnumerable<CommentReadDTO>> getAllAsync()
        {
            var response= await dBContext.Comment.ToListAsync();
            return mapper.Map<IEnumerable<CommentReadDTO>>(response);
        }

        public async Task<string> deleteAsync(int id)
        {
            var comment=await dBContext.Comment.FirstOrDefaultAsync(c=>c.commentId==id);
            if (comment != null)
            {
                dBContext.Comment.Remove(comment);
                await dBContext.SaveChangesAsync();
                return "Deletion Successful";
            }
            return "comment is null";
        }

    }
}
