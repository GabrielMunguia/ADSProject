using ADSProject.Models;
using ADSProyect.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ProfesorRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int agregarProfesor(ProfesorViewModel  profesorViewModel)
        {
            try
            {
                applicationDbContext.Profesores.Add(profesorViewModel);
                applicationDbContext.SaveChanges();
                return profesorViewModel.idProfesor;

            }
            catch (Exception )
            {

                return -1;
                throw;
            }
        }


        public int actualizarProfesor(int idProfesor, ProfesorViewModel profesorViewModel)
        {
            try
            {

                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == profesorViewModel.idProfesor);

                applicationDbContext.Entry(item).CurrentValues.SetValues(profesorViewModel);
                applicationDbContext.SaveChanges();

                return profesorViewModel.idProfesor;
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
        }


        public bool eliminarProfesor(int idProfesor)
        {
            try
            {
                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == idProfesor);


                item.estado = false;

                applicationDbContext.Attach(item);

                applicationDbContext.Entry(item).Property(x => x.estado).IsModified = true;

                applicationDbContext.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public ProfesorViewModel obtenerProfesorPorId(int idProfesor)
        {
            try
            {

                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == idProfesor);

                return item;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProfesorViewModel> obtenerProfesores()
        {
            try
            {
                return applicationDbContext.Profesores.Where(x => x.estado == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
