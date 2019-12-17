using EttvAPI.Data.Models;

namespace EttvAPI.Services.Communication
{
    public class VideoContentResponce : BaseResponse
    {
        public VideoContent VideoContent { get; private set; }
        public VideoContentResponce(bool success, string message, VideoContent videoContent) : base(success, message)
        {
            VideoContent = videoContent;
        }

        public VideoContentResponce(VideoContent videoContent) : this(true, string.Empty, videoContent) { }

        public VideoContentResponce(string message) : this(false, message, null) { }
    }
}
