using AutoMapper;
using Connectify.Entities.DbSet;
using Connectify.Entities.Dtos.Responses;

namespace Connectify.Api.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Post, PostCommentResponse>()
               .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Image_url))
               .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));

            CreateMap<Comment, CommentResponse>()
                .ForMember(dest => dest.CommentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));

            CreateMap<Post, PostResponse>()
               .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));
        }
    }
}
