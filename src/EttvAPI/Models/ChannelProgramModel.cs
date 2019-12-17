using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EttvAPI.Models
{
    public class ChannelProgramModel
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int AppUserId { get; set; }
        public string VideoContentVideoId { get; set; }
        public VideoContentModel VideoContent { get; set; }
    }
}
