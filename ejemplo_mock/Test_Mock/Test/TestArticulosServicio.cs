using Data.Interfaces;
using Dominio.Service;
using DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Test
{
    [TestClass]
    public class TestArticulosServicio
    {
        [TestMethod]
        public void TestMethod1()
        {
            string contenido = "contenido";
            string titulo = "titulo";
            int autorId = 1;

            Mock<IArticulosRepository> articuloRepo = new Mock<IArticulosRepository>();
            Mock<IAutorRepository> autorRepo = new Mock<IAutorRepository>();
            autorRepo.Setup(a => a.AutorValido(It.IsAny<int>())).Returns(true);

            articuloRepo.Setup(a => a.InsertarArticulo(contenido, titulo, autorId)).Returns(1);
            articuloRepo.Setup(a => a.GetArticulo(1)).Returns(new Articulo()
            {
                Autor = new Autor()
                {
                    AutorId = autorId,
                    Nombre = "test"
                },
                Contenido = contenido,
                Fecha = DateTime.UtcNow,
                Id = 1,
                Titulo = titulo
            });

            ArticulosServicio servicio = new ArticulosServicio(articuloRepo.Object, autorRepo.Object);



            Articulo articulo = servicio.InsertarArticulo(contenido, titulo, autorId);

            Assert.AreEqual(autorId, articulo.Autor.AutorId);
            autorRepo.Verify(a => a.AutorValido(It.IsAny<int>()));

            articuloRepo.Verify(a => a.InsertarArticulo(contenido, titulo, autorId));
            articuloRepo.Verify(a => a.GetArticulo(1));

        }
    }
}
