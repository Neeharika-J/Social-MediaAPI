using SMApi.DTO;

namespace SMApi.Interfaces
{
    public interface ICommentService
    {
        Task<CommentReadDTO> createAsync(CommentCreateDTO commentCreateDTO);
        Task<CommentReadDTO> updateAsync(CommentUpdateDTO commentUpdateDTO);
        Task<IEnumerable<CommentReadDTO>> getByIdAsync(int id,string type);
        Task<IEnumerable<CommentReadDTO>> getAllAsync();
        Task<string> deleteAsync(int id);
    }
}
