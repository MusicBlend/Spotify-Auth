using System.Runtime.CompilerServices;

namespace SpotifyAuth.Entity
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}