using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly List<ProfesorViewModel> lstProfesores;

        public ProfesorRepository()
        {
            lstProfesores = new List<ProfesorViewModel>
            {
              new ProfesorViewModel
              {
                  idProfesor=1,nombreProfesor="Juan ",apellidoProfesor ="Perez",correoProfesor="test@test.com"
              }
            };
        }

        public int agregarProfesor(ProfesorViewModel materiaViewModel)
        {
            try
            {
                if (this.lstProfesores.Count > 0)
                {
                    materiaViewModel.idProfesor = lstProfesores.Last().idProfesor + 1;

                }
                else
                {
                    materiaViewModel.idProfesor = 1;
                }

                lstProfesores.Add(materiaViewModel);

                return materiaViewModel.idProfesor;

            }
            catch (Exception )
            {

                return -1;
                throw;
            }
        }


        public int actualizarProfesor(int idProfesor, ProfesorViewModel materiaViewModel)
        {
            try
            {

                lstProfesores[lstProfesores.FindIndex(x => x.idProfesor == idProfesor)] = materiaViewModel;
                return materiaViewModel.idProfesor;
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
                this.lstProfesores.RemoveAt(lstProfesores.FindIndex(x => x.idProfesor == idProfesor));
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

                var item = lstProfesores.Find(x => x.idProfesor == idProfesor);
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
                return this.lstProfesores;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
