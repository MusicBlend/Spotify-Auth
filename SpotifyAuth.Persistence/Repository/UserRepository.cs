using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpotifyAuth.Domain.Entities;
using SpotifyAuth.Domain.Interfaces.IRepository;
using SpotifyAuth.Persistence.Data;

namespace SpotifyAuth.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        
        public UserRepository(AppDbContext db)
        {
            _db = db;
        }
        
        public async Task<IEnumerable<User>> GetALl()
        {
            return await _db.Users.ToArrayAsync();
        }

        public async Task AddUser(User newUser)
        {
            await _db.Users.AddAsync(newUser);
            await _db.SaveChangesAsync();
        }
    }
}