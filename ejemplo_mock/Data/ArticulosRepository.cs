using Data.Interfaces;
using DTOs;
using System;

namespace Data
{
    public class ArticulosRepository : IArticulosRepository
    {
        public Articulo GetArticulo(int id)
        {
            throw new NotImplementedException();
        }

        public int InsertarArticulo(string contenido, string titulo, int autorId)
        {
            throw new NotImplementedException();
        }
    }
}
