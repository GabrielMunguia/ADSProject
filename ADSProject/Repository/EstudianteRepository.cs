using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly List<EstudianteViewModel> lstEstudiantes;

        public EstudianteRepository()
        {
            lstEstudiantes = new List<EstudianteViewModel>
            {
              new EstudianteViewModel
              {
                  idEstudiante=1,nombresEstudiante="Gabriel",apellidosEstudiante="Munguia",
                  codigoEstudiante="MR19I04001",correoEstudiante="mr19i04001@usonsonate.edu.sv"
              }
            };
        }

        public int agregarEstudiante(EstudianteViewModel estudianteViewModel)
        {
            try
            {
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

                lstEstudiantes[lstEstudiantes.FindIndex(x => x.idEstudiante == idEstudiante)] = estudianteViewModel;
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
                this.lstEstudiantes.RemoveAt(lstEstudiantes.FindIndex(x => x.idEstudiante == idEstudiante));
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

                var item = lstEstudiantes.Find(x => x.idEstudiante == idEstudiante);
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
                return this.lstEstudiantes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}