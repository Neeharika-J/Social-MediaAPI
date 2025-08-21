using SMApi.DTO;

namespace SMApi.Interfaces
{
    public interface IPostService
    {
        Task<PostReadDTO> createPostAsync(PostCreateDTO postCreateDTO);
        Task<IEnumerable<PostReadDTO>> getPostByIdAsync(int userId);
        Task<PostReadDTO> updatePostAsync(postUpdateDTO postUpdateDTO);
        Task<string> deleteAsync(int id);
    }
}
