using AutoMapper;

namespace Infrastructure.Data.AutoMapperProfile
{
    public class InfraProfile: Profile
    {
        public InfraProfile()
        {
            CreateMap<Domain.Entities.Category, Entity.Entities.Category>().ReverseMap();
            CreateMap<Domain.Entities.Topic, Entity.Entities.Topic>().ReverseMap();
            CreateMap<Domain.Entities.Post,Entity.Entities.Post>().ReverseMap();
            CreateMap<Domain.Entities.Comment, Entity.Entities.Comment>().ReverseMap();
            CreateMap<Domain.Entities.User, Entity.Entities.User>().ReverseMap();
        }
    }
}
