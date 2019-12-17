using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EttvAPI.Data.Models
{
    public class AppUser
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "binary(50)")]
        public string HashPassword { get; set; }
        public int ProfileId { get; set; }
        [Required] 
        public Profile Profile { get; set; }

        public ICollection<VideoContent> VideoContents { get; set; }
        public ICollection<ChannelProgram> ChannelPrograms { get; set; }
    }
}
