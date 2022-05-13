using ADSProject.Models;
using ADSProyect.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{

    public class GrupoRepository : IGrupoRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public GrupoRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int agregarGrupo(GrupoViewModel grupoViewModel)
        {
            try
            {

                applicationDbContext.Grupos.Add(grupoViewModel);
                applicationDbContext.SaveChanges();
                return grupoViewModel.idCarrera;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int actualizarGrupo(int idGrupo, GrupoViewModel grupoViewModel)
        {
            try
            {
                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.idGrupo == grupoViewModel.idGrupo);

                applicationDbContext.Entry(item).CurrentValues.SetValues(grupoViewModel);
                applicationDbContext.SaveChanges();

                return grupoViewModel.idCarrera;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool eliminarGrupo(int idGrupo)
        {
            try
            {
                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.idGrupo == idGrupo);


                item.estado = false;

                applicationDbContext.Attach(item);

                applicationDbContext.Entry(item).Property(x => x.estado).IsModified = true;

                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public GrupoViewModel obtenerGrupoPorID(int idGrupo)
        {
            try
            {
                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.idGrupo == idGrupo);

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GrupoViewModel> obtenerGrupos()
        {
            try
            {
                return applicationDbContext.Grupos.Where(x => x.estado == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
