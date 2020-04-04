using Data.Interfaces;
using DTOs;
using System;
using System.Threading.Tasks;

namespace Data
{
    public class AutorRepository : IAutorRepository
    {

        public Task<bool> AutorValido(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Autor> GetAutor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
