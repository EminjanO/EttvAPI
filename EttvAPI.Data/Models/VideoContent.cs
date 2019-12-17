using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EttvAPI.Data.Models
{
    public class VideoContent
    {
        [Key]
        public string VideoId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Tag { get; set; }
        [Required]
        public string Thumbnail { get; set; }
        [Required]
        public string SrcUri { get; set; }
        [Required]
        public string SrcExtention { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public ICollection<ChannelProgram> ChannelPrograms { get; set; }
    }
}
