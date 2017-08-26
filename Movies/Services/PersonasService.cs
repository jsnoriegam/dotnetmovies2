using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Movies.Entities;

namespace Movies.Services
{
    public class PersonasService : IPersonasService
    {
        PeliculasContext Context;

        public PersonasService(PeliculasContext context)
        {
            Context = context;
        }

        public PersonaWrapperView Obtener(int id) {
            return new PersonaWrapperView(Context.Personas.Include(p => p.DirectorDe).First(p => p.Id == id));
        }

        public List<PersonaWrapperView> ObtenerListado()
        {
            //Es necesario referenciar System.Linq
            return Context.Personas.AsNoTracking().Include(p => p.DirectorDe).Select(p => new PersonaWrapperView(p)).ToList();
        }

        public void Agregar(Persona persona)
        {
            Context.Personas.Add(persona);
            Context.SaveChanges();
        }

        public void Modificar(int id, Persona persona)
        {
            persona.Id = id;
            Context.Personas.Update(persona);
            Context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            Persona persona = Context.Personas.Find(id);
            Context.Personas.Remove(persona);
            Context.SaveChanges();
        }
    }

    public interface IPersonasService
    {
        PersonaWrapperView Obtener(int id);
        List<PersonaWrapperView> ObtenerListado();
        void Agregar(Persona persona);
        void Modificar(int id, Persona persona);
        void Eliminar(int id);
    }
}