using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Entities;
using Movies.Services;

namespace Movies.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    public class PeliculasController : Controller
    {
        IPeliculasService PeliculasService;
        public PeliculasController(IPeliculasService peliculasService)
        {
            PeliculasService = peliculasService;
        }

        /// <summary>
        /// Obtener una película
        /// </summary>
        /// <param name="id">Database Id de la película solicitada</param>
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            PeliculaWrapperView pelicula = PeliculasService.Obtener(id);
            if (pelicula != null)
            {
                return Ok(pelicula);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Obtener listado de películas
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            List<PeliculaWrapperView> peliculas = PeliculasService.ObtenerListado();
            if (peliculas != null && peliculas.Count > 0)
            {
                return Ok(peliculas);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Ingresar una película
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                // Si queremos ser mas estrictos con el modelo RESTful
                // Debemos retornar un Created con la entidad creada y la dirección para obtenerla
                PeliculaWrapperView view = PeliculasService.Agregar(pelicula);
                var uri = Url.RouteUrl(new {
                    action = "Get",
                    controller = "Peliculas",
                    id = view.Id
                });
                return Created(uri, view);
            }
            else
            {
                // Utilizo ToDictionary para obtener solo los datos relevantes del ModelState
                // Para usar ToDictionary se requere System.Linq
                return StatusCode(409, ModelState.ToDictionary(
                    ma => ma.Key,
                    ma => ma.Value.Errors.Select(e => e.ErrorMessage).ToList()
                ));
            }
        }

        /// <summary>
        /// Modificar una película
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                PeliculasService.Modificar(id, pelicula);
                return Ok();
            }
            else
            {
                return StatusCode(409, ModelState.ToDictionary(
                    ma => ma.Key,
                    ma => ma.Value.Errors.Select(e => e.ErrorMessage).ToList()
                ));
            }
        }

        /// <summary>
        /// Eliminar una película
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete([FromRoute] int id)
        {
            PeliculasService.Eliminar(id);
            return Ok();
        }
    }
}