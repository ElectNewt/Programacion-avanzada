using System;
using DTOs;
using Data.Interfaces;

namespace Dominio.Service
{
    public class ArticulosServicio
    {

        private readonly IAutorRepository _autorRepository;
        private readonly IArticulosRepository _articuloRepository;

        public ArticulosServicio(IArticulosRepository articulosRepository, IAutorRepository autorRepository)
        {
            _articuloRepository = articulosRepository;
            _autorRepository = autorRepository;
        }


        public Articulo InsertarArticulo(string contenido, string titulo, int autorId)
        {
            if (!_autorRepository.AutorValido(autorId))
            {
                throw new Exception("Autor not valido");
            }
            
            
            var articuloId = _articuloRepository.InsertarArticulo(contenido, titulo, autorId);

            return ConsultarArticulo(articuloId);
        }

        public Articulo ConsultarArticulo(int id)
        {
            return _articuloRepository.GetArticulo(id);
        }

    }
}
