using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EttvAPI.Data.Models;
using EttvAPI.Models;
using EttvAPI.Services.Communication;

namespace EttvAPI.Services.Interfaces
{
    public interface IVideoContentService
    {
        IEnumerable<VideoContent> List();
        VideoContentResponce Save(VideoContent videoContent);
        VideoContentResponce Update(string videoId, VideoContent videoContent);
        VideoContentResponce Delete(string videoId);
    }
}
