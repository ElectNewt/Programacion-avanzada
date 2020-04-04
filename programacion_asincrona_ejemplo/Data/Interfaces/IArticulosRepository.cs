using DTOs;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IArticulosRepository
    {
        Task<int> InsertarArticulo(string contenido, string titulo, int autorId);
        Task<Articulo> GetArticulo(int id);
    }
}
