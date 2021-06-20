using AutoMapper;
using Infrastructure.Data.Entity.Entities;

namespace Infrastructure.Data.AutoMapperProfile
{
    public class InfraProfile: Profile
    {
        public InfraProfile()
        {
            CreateMap<WebForum.Domain.Entities.Category, Category>().ReverseMap();
            CreateMap<WebForum.Domain.Entities.Topic, Topic>().ReverseMap();
            CreateMap<WebForum.Domain.Entities.Post, Post>().ReverseMap();
            CreateMap<WebForum.Domain.Entities.Comment, Comment>().ReverseMap();
            CreateMap<WebForum.Domain.Entities.User, User>().ReverseMap();
        }
    }
}
