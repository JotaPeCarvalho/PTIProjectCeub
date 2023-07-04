using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebProjectPTI.Data;
using WebProjectPTI.Repositorios.Interfaces;
using WebProjectPTI.Models;

namespace WebProjectPTI.Controllers
{
   
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepositorio _professorRepositorio;

        public ProfessorController(IProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Criar(Professor professor)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    Professor prof = await _professorRepositorio.Criar(professor);

                    if (prof != null)
                    {
                        return RedirectToAction("Index", "Login");
                    }

                    return View(professor);
                }
                return View(professor);
            } 
            catch (Exception ex)
            {
                return View(professor);
            }
        }

    }
}
