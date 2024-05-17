namespace Actividad.Models.Repositorio
{
    public interface IRepositorioPost
    {
        Task<List<Post>> GetAll();
        Task<Post?> Get(int id);

        Task Add(Post post, int id);

        Task Update( Post post);

        Task Delete(Post post);

    }
}
