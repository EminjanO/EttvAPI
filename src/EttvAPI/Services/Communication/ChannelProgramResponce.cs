using EttvAPI.Data.Models;

namespace EttvAPI.Services.Communication
{
    public class ChannelProgramResponce : BaseResponse
    {
        public ChannelProgram ChannelProgram { get; private set; }
        public ChannelProgramResponce(bool success, string message, ChannelProgram channelProgram) : base(success, message)
        {
            ChannelProgram = channelProgram;
        }
        public ChannelProgramResponce(ChannelProgram channelProgram) : this(true, string.Empty, channelProgram) { }

        public ChannelProgramResponce(string message) : this(false, message, null) { }
    }
}
