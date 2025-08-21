using AutoMapper;
using SMApi.DTO;
using SMApi.Models;

namespace SMApi.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<SMUser,UserCreateDTO>();
            CreateMap<UserCreateDTO, SMUser>();
            CreateMap<UserReadDTO, SMUser>();
            CreateMap<SMUser,UserReadDTO>();
            CreateMap<UserUpdateDTO, SMUser>();
            CreateMap<SMUser, UserUpdateDTO>();
            CreateMap<UserReadDTO, string>();

            //-----------POST----------------
            CreateMap<Posts,PostCreateDTO>();
            CreateMap<PostCreateDTO,Posts>();
            CreateMap<PostReadDTO, Posts>();
            CreateMap<Posts,PostReadDTO>();
            CreateMap<PostCreateDTO, PostReadDTO>();
            CreateMap<PostReadDTO, PostCreateDTO>();

            //----------COMMENT--------------   
            CreateMap<CommentCreateDTO, Comments>();
            CreateMap<CommentReadDTO, Comments>();
            CreateMap<CommentUpdateDTO, Comments>();
            CreateMap<Comments,CommentCreateDTO>();
            CreateMap<Comments, CommentReadDTO>();
            CreateMap<Comments, CommentUpdateDTO>();

            //----------LIKES----------------
            CreateMap<LikeCreateDTO, LikePosts>();
            CreateMap<LikeCreateDTO, LikeComments>();
            CreateMap<LikeComments, LikeCreateDTO>();
            CreateMap<LikePosts, LikeCreateDTO>();
            CreateMap<LikePosts, LikeReadDTO>();
            CreateMap<LikeComments, LikeReadDTO>();

            
        }
    }
}
