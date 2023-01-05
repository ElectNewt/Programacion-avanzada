using System;
using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Dominio.Service;
using DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test
{
    [TestClass]
    public class TestArticulosServicioFake
    {
        [TestMethod]
        public void TestMethod1()
        {
            string contenido = "contenido";
            string titulo = "titulo";
            int autorId = 1;

          
            Mock<IAutorRepository> autorRepo = new Mock<IAutorRepository>();
            autorRepo.Setup(a => a.AutorValido(It.IsAny<int>())).Returns(true);

            FakeArticulos articuloRepo = new FakeArticulos();

            ArticulosServicio servicio = new ArticulosServicio(articuloRepo, autorRepo.Object);



            Articulo articulo = servicio.InsertarArticulo(contenido, titulo, autorId);

            Assert.AreEqual(1, articulo.Id);
            Assert.AreEqual(autorId, articulo.Autor.AutorId);
            autorRepo.Verify(a => a.AutorValido(It.IsAny<int>()));
        }


        public class FakeArticulos : IArticulosRepository
        {
            public List<Articulo> Articulos { get; set; }

            public int currentIdentifier { get; private set; }
            
            public FakeArticulos()
            {
                Articulos = new List<Articulo>();
                currentIdentifier = 0;
            }


            public int InsertarArticulo(string contenido, string titulo, int autorId)
            {
                Articulo articulo = new Articulo()
                {
                    Autor = new Autor()
                    {
                        AutorId = autorId,
                        Nombre = "test"
                    },
                    Contenido = contenido,
                    Fecha = DateTime.UtcNow,
                    Id = ++currentIdentifier,
                    Titulo = titulo
                };

                Articulos.Add(articulo);
                
                return articulo.Id;
            }

            public Articulo GetArticulo(int id)
                => Articulos.FirstOrDefault(articulo => articulo.Id == id);

        }
    }
}