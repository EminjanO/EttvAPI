using EttvAPI.Data.Models;

namespace EttvAPI.Services.Communication
{
    public class ProfileResponce : BaseResponse
    {
        public Profile Profile { get; private set; }
        public ProfileResponce(bool success, string message, Profile profile) : base(success, message)
        {
            Profile = profile;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="profile">Saved profile.</param>
        /// <returns>Response.</returns>
        public ProfileResponce(Profile profile) : this(true, string.Empty, profile)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProfileResponce(string message) : this(false, message, null)
        { }
    }
}
