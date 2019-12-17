namespace EttvAPI.Models
{
    public class AppUserModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string HashPassWord { private get; set; }
        public int ProfileId { get; set; }
        public ProfileModel Profile { get; set; }
    }
}
