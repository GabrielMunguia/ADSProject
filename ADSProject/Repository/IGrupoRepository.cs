using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public interface IGrupoRepository
    {
        int agregarGrupo(GrupoViewModel grupoViewModel);

        int actualizarGrupo(int idGrupo, GrupoViewModel grupoViewModel);

        bool eliminarGrupo(int idGrupo);
        List<GrupoViewModel> obtenerGrupos();

        List<GrupoViewModel> obtenerGrupos(String[] includes);

        GrupoViewModel obtenerGrupoPorID(int idGrupo,string[] includes);

        GrupoViewModel obtenerGrupoPorID(int idGrupo);
    }
}
