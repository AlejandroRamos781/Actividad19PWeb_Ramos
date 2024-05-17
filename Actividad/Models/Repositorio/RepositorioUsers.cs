using Actividad.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad.Models.Repositorio
{
    public class RepositorioUsers : IRepositorioUsers
    {
        private readonly UserDbContext _context;

        public RepositorioUsers(UserDbContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Update(int id, User user)
        {
            var currentUser = await _context.Users.FindAsync(id);
            if (currentUser != null)
            {
                currentUser.Name = user.Name;
                currentUser.Email = user.Email;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> GetUserByEmailAndPassword(string? email, string? password)
        {
            var userFind =  await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            if (userFind != null)
            {
                return userFind;
            }
            else
            {
                return null;
            }
        }
    }
}

