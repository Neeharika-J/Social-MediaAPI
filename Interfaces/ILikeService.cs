using SMApi.DTO;
using System.Runtime.CompilerServices;

namespace SMApi.Interfaces
{
    public interface ILikeService
    {
        Task<string> create(LikeCreateDTO likeCreateDTO);
        Task<string> remove(LikeRemoveDTO likeRemoveDTO);
        Task<int> getLikesCountOnPost(int postId);
        Task<int> getLikesCountOnComment(int commentId);
    }
}
