using ADSProject.Models;
using ADSProyect.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class CarreraRepository : ICarreraRepository
    {
        // private readonly List<CarrerasViewModel> lstCarreras;
        private readonly ApplicationDbContext applicationDbContext;
        public CarreraRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int actualizarCarrera(int idCarrera, CarrerasViewModel carreraViewModel)
        {
            try
            {

                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.idCarrera == carreraViewModel.idCarrera);

                applicationDbContext.Entry(item).CurrentValues.SetValues(carreraViewModel);
                applicationDbContext.SaveChanges();

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
                applicationDbContext.Carreras.Add(carreraViewModel);
                applicationDbContext.SaveChanges();
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
                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.idCarrera == idCarrera);
        

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

        public CarrerasViewModel obtenerCarreraPorID(int idCarrera)
        {
            try
            {

                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.idCarrera == idCarrera);

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
                return applicationDbContext.Carreras.Where(x => x.estado == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }



    }


      
       

     

    


        

    
   
}
