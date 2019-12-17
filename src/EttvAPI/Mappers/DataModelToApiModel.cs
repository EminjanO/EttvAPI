using EttvAPI.Data.Models;
using EttvAPI.Models;
using Profile = AutoMapper.Profile;

namespace EttvAPI.Mappers
{
    public class DataModelToApiModel : Profile
    {
        public DataModelToApiModel()
        {
            CreateMap<AppUser,AppUserModel>();
            CreateMap<Data.Models.Profile,ProfileModel>();
            CreateMap<VideoContent, VideoContentModel>();
            CreateMap<ChannelProgram, ChannelProgramModel>();
        }
    }
}
