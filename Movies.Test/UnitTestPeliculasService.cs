using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Entities;
using Movies.Services;

namespace Movies.Test
{
    [TestClass]
    public class UnitTestPeliculasService
    {
        PeliculasContext Context;
        IPeliculasService PeliculasService;
        public UnitTestPeliculasService() {
            Context = new PeliculasContext(new DbContextOptionsBuilder<PeliculasContext>().UseInMemoryDatabase(databaseName: "Peliculas").Options);
            PeliculasService = new PeliculasService(Context);
        }
        [TestInitialize]
        public void TestInitialize()
        {
            var persona = new Persona() {
                Nombre = "Zack",
                Apellido = "Snyder",
                CodigoIMDB = "nm0811583"
            };
            Context.Personas.Add(persona);
            var pelicula = new Pelicula() {
                Nombre = "Batman v Superman: Dawn of Justice",
                CodigoIMDB = "tt2975590",
                Resumen = "Fearing that the actions of Superman are left unchecked, Batman takes on the Man of Steel, while the world wrestles with what kind of a hero it really needs.",
                Director = persona
            };
            Context.Peliculas.Add(pelicula);
            Context.SaveChanges();
        }
        [TestMethod]
        public void TestMethodAgregar()
        {
            Console.WriteLine("Agregar una película");
            var pelicula = new Pelicula() {
                Nombre = "Wonder Woman",
                CodigoIMDB = "tt0451279"
            };
            PeliculasService.Agregar(pelicula);
            Assert.AreEqual(Context.Peliculas.ToList().Count, 2);
        }
        [TestMethod]
        public void TestMethodListar()
        {
            Console.WriteLine("Obtener listado de películas");
            var peliculas = PeliculasService.ObtenerListado();
            Assert.IsInstanceOfType(peliculas, typeof(List<PeliculaWrapperView>));
        }
    }
}
