using ADSProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Controllers
{
    public class EstudianteController : Controller
    {

        private readonly IEstudianteRepository estudianteRepository;


        public EstudianteController(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
        }


        public IActionResult Index()
        {
            try
            {
                var item = estudianteRepository.obtenerEstudiantes();
                return View(item);

            }
            catch (Exception)
            {

                throw;
            }
        }
           
    }
}
