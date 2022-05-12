using ADSProject.Models;
using ADSProyect.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADSProject.Repository
{
    public class EstudianteRepository : IEstudianteRepository
    {
        //private readonly List<EstudianteViewModel> lstEstudiantes;
        private readonly ApplicationDbContext applicationDbContext;
        public EstudianteRepository(ApplicationDbContext applicationDbContext)
        {
            /*lstEstudiantes = new List<EstudianteViewModel>
            {
              new EstudianteViewModel
              {
                  idEstudiante=1,nombresEstudiante="Gabriel",apellidosEstudiante="Munguia",
                  codigoEstudiante="MR19I04001",correoEstudiante="mr19i04001@usonsonate.edu.sv"
              }
            };*/
            this.applicationDbContext = applicationDbContext;
        }

        public int agregarEstudiante(EstudianteViewModel estudianteViewModel)
        {
            try
            {
                /*
                  if (this.lstEstudiantes.Count > 0)
                 {
                     estudianteViewModel.idEstudiante = lstEstudiantes.Last().idEstudiante + 1;

                 }
                 else
                 {
                     estudianteViewModel.idEstudiante = 1;
                 }

                 lstEstudiantes.Add(estudianteViewModel);

                 return estudianteViewModel.idEstudiante;
                 */
                applicationDbContext.Estudiantes.Add(estudianteViewModel);
                applicationDbContext.SaveChanges();
                return estudianteViewModel.idEstudiante;

            }
            catch (Exception err)
            {

                return -1;
                throw;
            }
        }


        public int actualizarEstudiante(int idEstudiante, EstudianteViewModel estudianteViewModel)
        {
            try
            {


                //  lstEstudiantes[lstEstudiantes.FindIndex(x => x.idEstudiante == idEstudiante)] = estudianteViewModel;
                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.idEstudiante == estudianteViewModel.idEstudiante);
           
                applicationDbContext.Entry(item).CurrentValues.SetValues(estudianteViewModel);
                applicationDbContext.SaveChanges();

                return estudianteViewModel.idEstudiante;
                 
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
        }


        public bool eliminarEstudiante(int idEstudiante)
        {
            try
            {
                // this.lstEstudiantes.RemoveAt(lstEstudiantes.FindIndex(x => x.idEstudiante == idEstudiante));
                 var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.idEstudiante == idEstudiante);
                //   applicationDbContext.Remove(item);
                //  applicationDbContext.SaveChanges();

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

        public EstudianteViewModel obtenerEstudiantePorID(int idEstudiante)
        {
            try
            {

                //var item = lstEstudiantes.Find(x => x.idEstudiante == idEstudiante);
                var item = applicationDbContext.Estudiantes.SingleOrDefault(x=>x.idEstudiante== idEstudiante);

                return item;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EstudianteViewModel> obtenerEstudiantes()
        {
            try
            {
                //Obtener todos los estudiantes sin filtros
               // return applicationDbContext.Estudiantes.ToList();

                //obtener todos los estudiantes que tengan el estado en 1 
                return applicationDbContext.Estudiantes.Where(x => x.estado == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}