using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpotifyAPI.Web;


namespace SpotifyAuth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotifyAuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SpotifyAuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpGet]
        public Array UserAuthentication()
        {
            var loginRequest = new LoginRequest(
                new Uri("http://localhost:3000/communities"),
                _configuration.GetValue<string>("clientId"),
                LoginRequest.ResponseType.Code
            ) 
            {
                Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }
            };
            var uri = loginRequest.ToUri();
            string[] arr = {uri.ToString()};
            
            return arr;
        }
        
        [HttpGet("{code}")]
        public async Task<Array> GetAccessToken(string code)
        {
            Uri redirectUrl = new Uri("http://localhost:3000/communities");
            
            var response = await new OAuthClient().RequestToken(
                new AuthorizationCodeTokenRequest(
                    _configuration.GetValue<string>("clientId"), 
                    _configuration.GetValue<string>("clientSecret"), 
                    code, redirectUrl)
            );
            var spotify = new SpotifyClient(response.AccessToken);
            
            string[] arr = {response.AccessToken};
            return arr;
        }
        
        [HttpGet("id/{accessToken}")]
        public async Task<Array> GetUserId(string accessToken)
        {
            var spotify = new SpotifyClient(accessToken);
            var user = await spotify.UserProfile.Current();
            string[] arr = {user.Id};
            return arr;
        }
        
        [HttpGet("name/{accessToken}")]
        public async Task<Array> GetName(string accessToken)
        {
            var spotify = new SpotifyClient(accessToken);
            var user = await spotify.UserProfile.Current();
            string[] arr = {user.DisplayName};
            return arr;
        }
    }
}