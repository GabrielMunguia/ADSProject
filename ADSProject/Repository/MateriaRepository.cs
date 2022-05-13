using ADSProject.Models;
using ADSProyect.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public MateriaRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int agregarMateria(MateriaViewModel materiaViewModel)
        {
            try
            {

                applicationDbContext.Materias.Add(materiaViewModel);
                applicationDbContext.SaveChanges();
                return materiaViewModel.idMateria;

            }
            catch (Exception err)
            {

                return -1;
                throw;
            }
        }


        public int actualizarMateria(int idMateria, MateriaViewModel materiaViewModel)
        {
            try
            {

                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == materiaViewModel.idMateria);

                applicationDbContext.Entry(item).CurrentValues.SetValues(materiaViewModel);
                applicationDbContext.SaveChanges();

                return materiaViewModel.idMateria;
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
        }


        public bool eliminarMateria(int idMateria)
        {
            try
            {
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);


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

        public MateriaViewModel obtenerMateriaPorID(int idMateria)
        {
            try
            {

                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);

                return item;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MateriaViewModel> obtenerMaterias()
        {
            try
            {
                return applicationDbContext.Materias.Where(x => x.estado == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
