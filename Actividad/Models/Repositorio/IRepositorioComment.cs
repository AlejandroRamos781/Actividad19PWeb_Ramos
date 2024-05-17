using System.Runtime.CompilerServices;

namespace Actividad.Models.Repositorio
{
    public interface IRepositorioComment
    {
        Task<List<Comment>> GetAll();
        Task<Comment?> Get(int id);
        
        Task<List<Comment>> GetByPostId(int id);

        Task<List<(Comment comment, string UserName)>> GetPostsAndUserNamesForPost(int postId);

        Task<Comment> Add(Comment comment, int postId, int userId);

        Task Update(Comment comment);

        Task Delete(Comment comment);
    }
}
