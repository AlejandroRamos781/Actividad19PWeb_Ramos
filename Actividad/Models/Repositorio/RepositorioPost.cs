
using Microsoft.EntityFrameworkCore;

namespace Actividad.Models.Repositorio
{
    public class RepositorioPost : IRepositorioPost
    {
        private readonly UserDbContext _context;

        public RepositorioPost(UserDbContext context)
        {
            _context = context;
        }

       
        public async Task Add(Post post, int id)
        {

            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                post.User = user;
                await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();

            } else
            {
                throw new Exception("valio verha");
            }
           
        }

        public async Task Delete(Post _post)
        {
            
                _context.Posts.Remove(_post);
                await _context.SaveChangesAsync();
            
            
        }

        public async Task<Post?> Get(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<List<Post>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task Update(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
