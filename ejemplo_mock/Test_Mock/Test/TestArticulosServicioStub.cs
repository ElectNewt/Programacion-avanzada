using System;
using Data.Interfaces;
using Dominio.Service;
using DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test
{
    [TestClass]
    public class TestArticulosServicioStub
    {
        [TestMethod]
        public void TestMethod1()
        {
            string contenido = "contenido";
            string titulo = "titulo";
            int autorId = 1;

          
            Mock<IAutorRepository> autorRepo = new Mock<IAutorRepository>();
            autorRepo.Setup(a => a.AutorValido(It.IsAny<int>())).Returns(true);

            ArticulosStub articuloStubRepo = new ArticulosStub();

            ArticulosServicio servicio = new ArticulosServicio(articuloStubRepo, autorRepo.Object);



            Articulo articulo = servicio.InsertarArticulo(contenido, titulo, autorId);

            Assert.AreEqual(1, articulo.Id);
            autorRepo.Verify(a => a.AutorValido(It.IsAny<int>()));
        }


        public class ArticulosStub : IArticulosRepository
        {
            public int InsertarArticulo(string contenido, string titulo, int autorId)
            {
                return 1;
            }

            public Articulo GetArticulo(int id)
            {
                return new Articulo()
                {
                    Autor = new Autor()
                    {
                        AutorId = 1,
                        Nombre = "test"
                    },
                    Contenido = "contenido",
                    Fecha = DateTime.UtcNow,
                    Id = id,
                    Titulo = "titulo"
                };
            }
        }
        
    }
}