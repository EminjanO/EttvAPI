using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EttvAPI.Data.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<AppUser> AppUsers{ get; set; }
    }
}