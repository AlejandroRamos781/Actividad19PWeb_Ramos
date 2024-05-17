
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Actividad.Models.Repositorio
{
    public class RepositorioComment : IRepositorioComment
    {

        private readonly UserDbContext _context;

       

        public RepositorioComment(UserDbContext context)
        {
            _context = context;
        }
        public async Task<Comment> Add(Comment comment, int postId, int userId)
        {
            
           var user =  await _context.Users.FindAsync(userId);
           var post =await _context.Posts.FindAsync(postId);
            if(post != null && user != null) {
                comment.User = user;
                comment.Post = post;
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
            }
            return comment;
        }

        public async Task Delete(Comment comment)
        {
            _context.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<Comment?> Get(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<List<Comment>> GetByPostId(int postId)
        {
            return await _context.Comments.Where(comment => comment.Post.PostId == postId).ToListAsync();
        }

        public  async Task Update(Comment comment)
        {
               _context.Comments.Update(comment);
                await _context.SaveChangesAsync();
        }
            

        public async Task<List<(Comment comment, string UserName)>> GetPostsAndUserNamesForPost(int postId)
        {
          
            var comments = await GetByPostId(postId);


            var postUserPairs = (
                from comment in comments
                join user in _context.Users on comment.User.Id equals user.Id
                select (Comment: comment, UserName: user.Name)
            ).ToList();

            return postUserPairs;
        }



    }
}
