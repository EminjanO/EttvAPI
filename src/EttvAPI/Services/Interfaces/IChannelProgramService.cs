using System.Collections.Generic;
using EttvAPI.Data.Models;
using EttvAPI.Services.Communication;

namespace EttvAPI.Services.Interfaces
{
    public interface IChannelProgramService
    {
        IEnumerable<ChannelProgram> List();
        ChannelProgramResponce Save(ChannelProgram channelProgram);
        ChannelProgramResponce Update(int id, ChannelProgram channelProgram);
        ChannelProgramResponce Delete(int id);
    }
}
