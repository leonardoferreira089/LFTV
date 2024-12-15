using LFTV.Domain.Entities;
using LFTV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTV.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LFTVContext _context;

        public UserRepository(LFTVContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Implémentation de la méthode DeleteAsync
        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);  // Supprime l'utilisateur de la base de données
            await _context.SaveChangesAsync();  // Enregistre les modifications
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
