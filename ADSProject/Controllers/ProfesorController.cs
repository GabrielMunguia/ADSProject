
using ADSProject.Models;
using ADSProject.Utils;
using ADSProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ADSProject.Controllers
{
    public class ProfesorController : Controller
    {
        private readonly IProfesorRepository profesorRepository;
        private readonly ILogger<EstudianteController> logger;

        public ProfesorController(IProfesorRepository profesorRepository, ILogger<EstudianteController> logger)
        {
            this.profesorRepository = profesorRepository;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var item = profesorRepository.obtenerProfesor();
                return View(item);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]

        public IActionResult Form (int? idProfesor, Operaciones operaciones)
        {
            try
            {
                var profesor = new ProfesorViewModel();
                if(idProfesor.HasValue)
                {
                    profesor = profesorRepository.obtenerProfesorPorID(idProfesor.Value);
                }
                ViewData["Operaciones"] = operaciones;
                return View(profesor);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Form (ProfesorViewModel profesorViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = 0;
                    if (profesorViewModel.idProfesor == 0)
                    {
                       id = profesorRepository.agregarProfesor(profesorViewModel);
                    }
                    else
                    {
                       id = profesorRepository.actualizarProfesor(profesorViewModel.idProfesor, profesorViewModel);
                    }

                    if (id > 0)
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
        [HttpPost]
        public IActionResult Delete(int idProfesor)
        {
            try
            {
                profesorRepository.eliminarProfesor(idProfesor);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
