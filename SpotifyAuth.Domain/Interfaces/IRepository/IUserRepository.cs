using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAuth.Domain.Entities;

namespace SpotifyAuth.Domain.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetALl();
        Task AddUser(User newUser);
    }
}