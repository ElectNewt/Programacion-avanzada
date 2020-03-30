using Dominio.Service;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class ArticulosController : Controller
    {

        private readonly ArticulosServicio _articulosServicio;
        public ArticulosController(ArticulosServicio articulosServicio)
        {
            _articulosServicio = articulosServicio;
        }

        [HttpPost]
        [Route("Articulo")]
        public Articulo InsertarArticulo(string contenido, string titulo, int autor)
        {
            var resultado = _articulosServicio.InsertarArticulo(contenido, titulo, autor);

            return resultado;
        }

        [HttpGet]
        [Route("Articulo/{id}")]
        public Articulo ConsultarArticulo(int id)
        {
            var resultado = _articulosServicio.ConsultarArticulo(id);

            return resultado;
        }

    }
}