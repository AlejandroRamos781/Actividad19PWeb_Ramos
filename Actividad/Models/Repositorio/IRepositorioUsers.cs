using Actividad.Models;

namespace Actividad.Models.Repositorio
{
    public interface IRepositorioUsers
    {
        Task<List<User>> GetAll();

        Task<User?> Get(int id);

        Task<User> Add(User user);

        Task Update(int id, User user);

        Task Delete(int id);

        Task<User?> GetUserByEmailAndPassword(string? email, string? password);
    }
}
