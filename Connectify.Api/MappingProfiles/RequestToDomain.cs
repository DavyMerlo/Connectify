using AutoMapper;
using Connectify.Entities.DbSet;
using Connectify.Entities.Dtos.Requests;

namespace Connectify.Api.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreatePostRequest, Post>()
               .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));


            CreateMap<UpdatePostRequest, Post>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PostId));


            CreateMap<CreateCommentRequest, Comment>()
               .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));


            CreateMap<UpdateCommentRequest, Comment>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CommentId));
        }
    }
}
