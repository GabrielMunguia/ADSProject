using ADSProject.Models;
using ADSProject.Repository;
using ADSProject.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly IEstudianteRepository estudianteRepository;
        private readonly ICarreraRepository carreraRepository;
        private readonly ILogger<EstudianteController> logger;

        public EstudianteController(IEstudianteRepository estudianteRepository, ICarreraRepository carreraRepository, ILogger<EstudianteController> logger)
        {
            this.estudianteRepository = estudianteRepository;
            this.carreraRepository = carreraRepository;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var item = estudianteRepository.obtenerEstudiantes(new String[] { "Carreras" });

                return View(item);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [HttpGet]
        public IActionResult Form(int? idEstudiante, Operaciones operaciones)
        {
            try
            {
                var estudiante = new EstudianteViewModel();

                if (idEstudiante.HasValue)
                {
                    estudiante = estudianteRepository.obtenerEstudiantePorID(idEstudiante.Value);
                }
                // Indica el tipo de operacion que es esta realizando
                ViewData["Operaciones"] = operaciones;

                // obteniendo todas las carreras disponibles
                ViewBag.Carreras = carreraRepository.obtenerCarrera();

                return View(estudiante);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Form(EstudianteViewModel estudianteViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = 0;
                    if (estudianteViewModel.idEstudiante == 0) // En caso de insertar
                    {
                       id = estudianteRepository.agregarEstudiante(estudianteViewModel);
                    }
                    else // En caso de actualizar
                    {
                         id = estudianteRepository.actualizarEstudiante
                            (estudianteViewModel.idEstudiante, estudianteViewModel);
                    }

                    if(id > 0)
                    {
                        return StatusCode(StatusCodes.Status200OK);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status202Accepted);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

               
                // return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost] // se cambió a Post para eliminar el registro
        public IActionResult Delete(int idEstudiante)
        {
            try
            {
                estudianteRepository.eliminarEstudiante(idEstudiante);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
