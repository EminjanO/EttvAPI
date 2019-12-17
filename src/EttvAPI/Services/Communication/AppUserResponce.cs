using EttvAPI.Data.Models;

namespace EttvAPI.Services.Communication
{
    public class AppUserResponce : BaseResponse
    {
        public AppUser AppUser { get; private set; }
        public AppUserResponce(bool success, string message, AppUser appUser) : base(success, message)
        {
            AppUser = appUser;
        }

        public AppUserResponce(AppUser appUser) : this(true, string.Empty, appUser) { }

        public AppUserResponce(string message) : this(false, message, null) { }
    }
}
