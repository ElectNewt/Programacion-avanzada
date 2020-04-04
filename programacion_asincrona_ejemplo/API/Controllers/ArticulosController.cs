using Dominio.Service;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

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
        public async Task<Articulo> InsertarArticulo(string contenido, string titulo, int autor)
        {
            var resultado = _articulosServicio.InsertarArticulo(contenido, titulo, autor);

            return await resultado;
        }

        [HttpGet]
        [Route("Articulo/{id}")]
        public async Task<Articulo> ConsultarArticulo(int id)
        {
            Task<Articulo> resultado =  _articulosServicio.ConsultarArticulo(id);

            return await resultado;
        }

        [HttpGet]
        [Route("Articulos")]
        public async Task<Articulo> ConsultarTodosLosAritucluos()
        {
            var resultado =  _articulosServicio.ConsultarArticulo(1);
            var resultado2 =  _articulosServicio.ConsultarArticulo(2);
            var resultado3 =  _articulosServicio.ConsultarArticulo(3);


            await Task.WhenAll(
                resultado, resultado2, resultado3
                );


           
            return  resultado.Result;
        }

        [HttpGet]
        [Route("EjemploHttpAwait")]
        public async Task<string> EjemploHttpAwait()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            await HttpService.HttpRequestAsync("https://www.marca.com");
            await HttpService.HttpRequestAsync("https://www.as.com");
            await HttpService.HttpRequestAsync("https://www.elpais.com");
            await HttpService.HttpRequestAsync("https://github.com");
            await HttpService.HttpRequestAsync("https://www.netmentor.es/");
            stopwatch.Stop();

            return $"tiempo en milisegundos utilizando await en cada llamada: {stopwatch.Elapsed.TotalMilliseconds}";
        }

        [HttpGet]
        [Route("EjemploHttpWhenAll")]
        public async Task<string> EjemploHttpWhenAll()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await Task.WhenAll(
                 HttpService.HttpRequestAsync("https://www.marca.com"),
                 HttpService.HttpRequestAsync("https://www.as.com"),
                 HttpService.HttpRequestAsync("https://www.elpais.com"),
                 HttpService.HttpRequestAsync("https://github.com"),
                 HttpService.HttpRequestAsync("https://www.netmentor.es/")
                );

            stopwatch.Stop();

            return $"tiempo en milisegundos utilizando when all: {stopwatch.Elapsed.TotalMilliseconds}";
        }

        [HttpGet]
        [Route("EjemploHttpTaskAwait")]
        public async Task<string> EjemploHttpTaskAwait()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Task<string> request1 = HttpService.HttpRequestAsync("https://www.marca.com");
            var request2 = HttpService.HttpRequestAsync("https://www.as.com");
            var request3 = HttpService.HttpRequestAsync("https://www.elpais.com");
            var request4 = HttpService.HttpRequestAsync("https://github.com");
            var request5 = HttpService.HttpRequestAsync("https://www.netmentor.es/");

            await request1;
            await request2;
            await request3;
            await request4;
            await request5;

            stopwatch.Stop();

            

            return $"tiempo en milisegundos utilizando await en cada llamada: {stopwatch.Elapsed.TotalMilliseconds}";
        }


    }
}