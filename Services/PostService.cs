using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMApi.dbcontext;
using SMApi.DTO;
using SMApi.Interfaces;
using SMApi.Models;

namespace SMApi.Services
{
    public class PostService: IPostService
    {
        private readonly ApplicationDBContext dbcontext;
        private readonly IMapper mapper;
        
        public PostService(ApplicationDBContext dbcontext,IMapper mapper)
        {
            this.dbcontext = dbcontext;
            this.mapper = mapper;
        }


        public async Task<PostReadDTO> createPostAsync(PostCreateDTO postCreateDTO)
        {
            var post = mapper.Map<Posts>(postCreateDTO);
            post.createdAt = DateTime.Now;
            try
            {
                dbcontext.Post.Add(post);
                await dbcontext.SaveChangesAsync();
                return mapper.Map<PostReadDTO>(post);
            }
            catch (Exception ex) 
            {
                throw; 
            }
        }

        public async Task<IEnumerable<PostReadDTO>> getPostByIdAsync(int id)
        {
            var list=await dbcontext.Post.Where(p=>p.userId==id).ToListAsync();
            return mapper.Map<IEnumerable<PostReadDTO>>(list);
        }

        public async Task<PostReadDTO> updatePostAsync(postUpdateDTO postUpdateDTO)
        {
            var post = await dbcontext.Post.FirstOrDefaultAsync(p => p.postId == postUpdateDTO.postId);
            if (post != null)
            {
                post.content = postUpdateDTO.content;
            }
            await dbcontext.SaveChangesAsync();
            return mapper.Map<PostReadDTO>(post);

        }
        public async Task<string> deleteAsync(int id)
        {
            var post = dbcontext.Post.FirstOrDefault(p=>p.postId == id);    
            if(post != null)
            {
                dbcontext.Post.Remove(post);
                await dbcontext.SaveChangesAsync();
                return "Deletion successful";
            }
            return "post is null";
        }


    }
}
