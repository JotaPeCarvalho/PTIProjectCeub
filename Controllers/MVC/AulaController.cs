using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebProjectPTI.Data;
using WebProjectPTI.Helper;
using WebProjectPTI.Infra.Enum;
using WebProjectPTI.Models;
using WebProjectPTI.Repositorios.Interfaces;

namespace WebProjectPTI.Controllers
{

    public class AulaController : Controller
    {
        private readonly IAulaRepositorio _aulaRepositorio;
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly IProfessorRepositorio _professorRepositorio;
        private readonly SessionHelper _session = new SessionHelper();

        public AulaController(IAulaRepositorio aulaRepositorio, IAlunoRepositorio alunoRepositorio, IProfessorRepositorio professorRepositorio)
        {
            _aulaRepositorio = aulaRepositorio;
            _alunoRepositorio = alunoRepositorio;
            _professorRepositorio = professorRepositorio;
        }

        public async Task<IActionResult> VerAulasDaSemana()
        {
            List<Aula> aulas = await _aulaRepositorio.RetornaAulasProximas();
            return View(aulas);
        }

        public async Task<IActionResult> VerMais(int id)
        {
            Aula aulaById = await _aulaRepositorio.GetById(id);
            return View(aulaById);
        }

        public IActionResult CriarAula()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CriarAula(Aula aula)
        {
            try
            {
                if (aula.Id_Aluno == 0 || aula.Id_Aluno == null)
                {
                    TempData["ErrorMessage"] = "Esse aluno não existe na base de dados, por favor, antes de marcar aula, adicione o aluno!";
                    return View();
                }

                Professor professor = await _professorRepositorio.GetProfessorLogado();

                aula.Id_Professor = professor.Id_Professor;

                DayOfWeek diaDaSemana = aula.DataMesAula.DayOfWeek;

                aula.DiaSemanaAula = (DiaAulaEnum)diaDaSemana;

                await _aulaRepositorio.Add(aula);

                TempData["SuccessMessage"] = "Aula cadastrada com sucesso";

                return View();

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
            
            public async Task<IActionResult> DeleteById(int id)
            {
                try
                {
                    await _aulaRepositorio.Delete(id);

                    TempData["SuccessMessage"] = "Aula cancelada com sucesso";

                    return RedirectToAction("VerAulasDaSemana");

                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Não foi possível apagar a aula";
                    return RedirectToAction("VerAulasDaSemana");
                }

            }
        }
}
