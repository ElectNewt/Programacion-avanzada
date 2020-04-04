using DTOs;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IAutorRepository
    {
        Task<Autor> GetAutor(int id);
        Task<bool> AutorValido(int id);
    }
}
