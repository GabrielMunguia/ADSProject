using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADSProject.Models;
namespace ADSProject.Repository
{
    public interface IMateriasRepository
    {
        List<MateriaViewModel> obtenerMaterias();

        int agregarMateria(MateriaViewModel materiaViewModel);

        int actualizarMateria(int idMateria, MateriaViewModel materiaViewModel);

        bool eliminarMateria(int idMateria);

        MateriaViewModel obtenerMateriaPorID(int idMateria);
    }
}
