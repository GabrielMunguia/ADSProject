using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class CarreraRepository : ICarreraRepository
    {
        private readonly List<CarrerasViewModel> lstCarreras;

        public CarreraRepository()
        {
            lstCarreras = new List<CarrerasViewModel>
            {
              new CarrerasViewModel
              {
                  idCarrera=1,nombreCarrera="Ing en sistemas",codigoCarrera="I04"

              }
            };
        }
        public int actualizarCarrera(int idCarrera, CarrerasViewModel carreraViewModel)
        {
            try
            {

                lstCarreras[lstCarreras.FindIndex(x => x.idCarrera == idCarrera)] = carreraViewModel;
                return carreraViewModel.idCarrera;
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
        }

        public int agregarCarrera(CarrerasViewModel carreraViewModel)
        {
            try
            {
                if (this.lstCarreras.Count > 0)
                {
                    carreraViewModel.idCarrera = lstCarreras.Last().idCarrera + 1;

                }
                else
                {
                    carreraViewModel.idCarrera = 1;
                }

                lstCarreras.Add(carreraViewModel);

                return carreraViewModel.idCarrera;

            }
            catch (Exception err)
            {

                return -1;
                throw;
            }
        }

        public bool eliminarCarrera(int idCarrera)
        {
            try
            {
                this.lstCarreras.RemoveAt(lstCarreras.FindIndex(x => x.idCarrera == idCarrera));
                return true;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public CarrerasViewModel obtenerCarreraPorID(int idCarrera)
        {
            try
            {

                var item = lstCarreras.Find(x => x.idCarrera == idCarrera);
                return item;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CarrerasViewModel> obtenerCarreras()
        {
            try
            {
                return this.lstCarreras;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }


      
       

     

    


        

    
   
}
