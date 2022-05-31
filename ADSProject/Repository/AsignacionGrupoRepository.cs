using ADSProject.Data;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class AsignacionGrupoRepository : IAsignacionGrupoRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AsignacionGrupoRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int agregarAsignacionGrupo(GrupoViewModel grupoviewModel)
        {
            try
            {
                if (grupoviewModel.AsignacionGrupos != null)
                {
                    agregarAsignacionGrupo(grupoviewModel.AsignacionGrupos);
                }

                return grupoviewModel.idGrupo;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void agregarAsignacionGrupo(ICollection<AsignacionGrupoViewModel> asignacionGrupoViewModel)
        {
            try
            {
                applicationDbContext.AsignacionGrupos.AddRange(asignacionGrupoViewModel);

                applicationDbContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int actualizarAsignacionGrupo(int idAGrupo, AsignacionGrupoViewModel asignacionGrupoViewModel)
        {
            try
            {
                var item = applicationDbContext.AsignacionGrupos.SingleOrDefault(x => x.idAsigacion == idAGrupo);

                applicationDbContext.Entry(item).CurrentValues.SetValues(asignacionGrupoViewModel);
                applicationDbContext.SaveChanges();

                return asignacionGrupoViewModel.idAsigacion;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public bool eliminarAsignacionGrupo(int idAGrupo)
        {
            try
            {
                var item = applicationDbContext.AsignacionGrupos.Where(x => x.idAsigacion == idAGrupo).ToList();

                applicationDbContext.AsignacionGrupos.RemoveRange(item);
                applicationDbContext.SaveChanges();

                return true;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AsignacionGrupoViewModel> obtenerAsignacionesGrupo()
        {
            try
            {
                return applicationDbContext.AsignacionGrupos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AsignacionGrupoViewModel obtenerAsignacionPorID(int idAGrupo)
        {
            try
            {
                return applicationDbContext.AsignacionGrupos.SingleOrDefault(x => x.idAsigacion == idAGrupo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
