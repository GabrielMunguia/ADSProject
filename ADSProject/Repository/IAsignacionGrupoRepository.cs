using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public interface IAsignacionGrupoRepository
    {
        public int agregarAsignacionGrupo(GrupoViewModel grupoviewModel);

        public void agregarAsignacionGrupo(ICollection<AsignacionGrupoViewModel> asignacionGrupoViewModel);

        public int actualizarAsignacionGrupo(int idAGrupo, AsignacionGrupoViewModel asignacionGrupoViewModel);

        public bool eliminarAsignacionGrupo(int idAGrupo);

        public List<AsignacionGrupoViewModel> obtenerAsignacionesGrupo();

        public AsignacionGrupoViewModel obtenerAsignacionPorID(int idAGrupo);
    }
}
