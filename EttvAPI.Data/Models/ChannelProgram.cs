using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EttvAPI.Data.Models
{
    public class ChannelProgram
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public DateTime ModifiedAt { get; set; }
        public int AppUserId { get; set; }
        [Required]
        public AppUser AppUser { get; set; }

        public string VideoContentVideoId { get; set; }
        [Required]
        public VideoContent VideoContent { get; set; }
    }
}
