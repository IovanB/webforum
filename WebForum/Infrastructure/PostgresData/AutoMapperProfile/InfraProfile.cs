using AutoMapper;
using System;
namespace Infrastructure.Data.AutoMapperProfile
{
    public class InfraProfile: Profile
    {
        public InfraProfile()
        {
            CreateMap<Domain.Entities.Category,Entity.Entities.Category>()
                //.ForMember(dest => dest.Id, opt => opt.Ignore()) 
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Entity.Entities.Category, Domain.Entities.Category>()
           .ConstructUsing(src => new Domain.Entities.Category(src.Id,src.Name));


            CreateMap<Domain.Entities.Topic, Entity.Entities.Topic >()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Entity.Entities.Topic, Domain.Entities.Topic>()
           .ConstructUsing(src => new Domain.Entities.Topic(src.Id, src.Name, src.CategoryId));

            CreateMap<Domain.Entities.Post, Entity.Entities.Post>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Entity.Entities.Post, Domain.Entities.Post>()
           .ConstructUsing(src => new Domain.Entities.Post(src.Id,src.Title, src.Content, src.TopicId));

            CreateMap<Domain.Entities.Comment, Entity.Entities.Comment>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Entity.Entities.Comment, Domain.Entities.Comment>()
           .ConstructUsing(src => new Domain.Entities.Comment(src.Id, src.Content, src.PostId));
        }
    }
}
