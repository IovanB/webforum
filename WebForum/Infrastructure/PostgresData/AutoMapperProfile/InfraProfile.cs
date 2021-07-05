using AutoMapper;

namespace Infrastructure.Data.AutoMapperProfile
{
    public class InfraProfile: Profile
    {
        public InfraProfile()
        {
            CreateMap<Entity.Entities.Category,Domain.Entities.Category>().ReverseMap();
            CreateMap<Entity.Entities.Topic, Domain.Entities.Topic > ().ReverseMap();
            CreateMap<Entity.Entities.Post, Domain.Entities.Post > ().ReverseMap();
            CreateMap<Entity.Entities.Comment, Domain.Entities.Comment > ().ReverseMap();
            CreateMap<Entity.Entities.User, Domain.Entities.User > ().ReverseMap();
        }
    }
}
