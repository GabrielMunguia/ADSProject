using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADSProject.Models;
namespace ADSProject.Repository
{
    public interface ICarreraRepository
    {
        List<CarrerasViewModel> obtenerCarreras();

        int agregarCarrera(CarrerasViewModel carreraViewModel);

        int actualizarCarrera(int idCarrera, CarrerasViewModel carreraViewModel);

        bool eliminarCarrera(int idCarrera);

        CarrerasViewModel obtenerCarreraPorID(int idCarrera);
    }
}
