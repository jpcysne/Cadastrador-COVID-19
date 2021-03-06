using Cadastrador_COVID_19.Model;
using Cadastrador_COVID_19.Model.ViewModels;
using Cadastrador_COVID_19.Service;
using Cadastrador_COVID_19.Service.Exception;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastrador_COVID_19.Controllers
{
    public class PacienteController : Controller
    {
        private readonly PacienteService _pacienteService;
        private readonly LocalVacinacaoService _localvacinacaoService;

        public PacienteController(PacienteService pacienteService, LocalVacinacaoService localvacinacaoService)
        {
            _pacienteService = pacienteService;
            _localvacinacaoService = localvacinacaoService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _pacienteService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var locaisVacinacao = await _localvacinacaoService.FindAllAsync();
            var viewModel = new PacienteViewModel { LocaisVacinacao = locaisVacinacao };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paciente paciente)
        {

            var idadePaciente = CalcularIdade( paciente.DatadeNascimento);

            if (idadePaciente < 65)
            {
                if (!ModelState.IsValid)
                {
                    //var locaisVacinacao = await _localvacinacaoService.FindAllAsync();
                    //var viewModel = new PacienteViewModel { Pacientes = paciente, LocaisVacinacao = locaisVacinacao };
                    return RedirectToAction(nameof(Error), new { message = "Idade do Paciente é menor que 65 anos!" });
                }
            }
            else
            {
                await _pacienteService.InsertAsync(paciente);
            }
            return RedirectToAction(nameof(Index));
        }

        public int CalcularIdade( DateTime DataNascimento)
        {
          
                ;
                int idade = DateTime.Today.Year - DataNascimento.Year;

                if (idade > 0)
                {
                    idade -= Convert.ToInt32(DateTime.Today.Date < DataNascimento.Date.AddYears(idade));
                }
                else
                {
                    idade = 0;
                }

                return idade;
            
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _pacienteService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _pacienteService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });

            }

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _pacienteService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _pacienteService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            List<LocalVacinacao> locaisVacinacao = await _localvacinacaoService.FindAllAsync();
            PacienteViewModel viewModel = new PacienteViewModel { Pacientes = obj, LocaisVacinacao = locaisVacinacao };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                var locaisVacinacao = await _localvacinacaoService.FindAllAsync();
                var viewModel = new PacienteViewModel { Pacientes = paciente, LocaisVacinacao = locaisVacinacao };
                return View(viewModel);
            }

            if (id != paciente.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _pacienteService.UpdateAsync(paciente);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        public IActionResult Error(string message)
        {

            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);

        }
    }
}

