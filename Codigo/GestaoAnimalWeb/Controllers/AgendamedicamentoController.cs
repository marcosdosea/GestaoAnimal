using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core;
using AutoMapper;
using Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Controllers
{
    public class AgendamedicamentoController : Controller
    {
        IAgendamedicamentoService _agendamedicamentoService;
        IMedicamentoService _medicamentoService;
        IAnimalService _animalService;
        IPessoaService _pessoaService;
        IConsultaService _consultaService;
        IMapper _mapper;

        public AgendamedicamentoController(IAgendamedicamentoService agendamedicamentoService,
            IMedicamentoService medicamentoService, 
            IAnimalService animalService,
            IConsultaService consultaService,
            IPessoaService pessoaService,
            IMapper mapper)
        {
            _agendamedicamentoService = agendamedicamentoService;
            _medicamentoService = medicamentoService;
            _animalService = animalService;
            _consultaService = consultaService;
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: AgendamedicamentoController
        public ActionResult Index()
        {
            var listaAgendamento = _agendamedicamentoService.ObterTodos();
            return View(listaAgendamento);
        }

        // GET: AgendamedicamentoController/Details/5
        public ActionResult Details(int id)
        {
            Agendamedicamento agendamedicamento = _agendamedicamentoService.Obter(id);
            Medicamento medicamento = _medicamentoService.Obter(agendamedicamento.IdMedicamento);
            Animal animal = _animalService.Obter(agendamedicamento.IdAnimal);
            Consulta consulta = _consultaService.Obter(agendamedicamento.IdConsulta);
            Pessoa pessoa = _pessoaService.Obter(agendamedicamento.IdPessoa);
            ViewBag.Medicamento = medicamento.Nome;
            ViewBag.Animal = animal.Nome;
            ViewBag.Consulta = consulta.Descricao;
            ViewBag.Pessoa = pessoa.Nome;
            AgendamedicamentoModel agendamedicamentoModel = _mapper.Map<AgendamedicamentoModel>(agendamedicamento);
            return View(agendamedicamentoModel);
        }

        // GET: AgendamedicamentoController/Create
        public ActionResult Create()
        {
            var frequencias = new[]
            {
                new SelectListItem { Value = "1", Text = "Diário" },
                new SelectListItem { Value = "2", Text = "Semanal" },
                new SelectListItem { Value = "3", Text = "Quinzenal" },
                new SelectListItem { Value = "4", Text = "Mensal" },
                new SelectListItem { Value = "5", Text = "Trimestral" },
                new SelectListItem { Value = "6", Text = "Semestral" },
                new SelectListItem { Value = "7", Text = "Anual" },
            };
            var intervalos = new[]
            {
                new SelectListItem { Value = "1", Text = "1x/dia" },
                new SelectListItem { Value = "2", Text = "2x/dia" },
                new SelectListItem { Value = "3", Text = "3x/dia" },
                new SelectListItem { Value = "4", Text = "4x/dia" },
                new SelectListItem { Value = "5", Text = "5x/dia" },
            };
            ViewBag.Frequencias = new SelectList(frequencias, "Value", "Text");
            ViewBag.Intervalos = new SelectList(intervalos, "Value", "Text");

            IEnumerable<Animal> listaAnimais = _animalService.ObterTodos();
            IEnumerable<MedicamentoDTO> listaMedicamentos = _medicamentoService.ObterTodos();
            IEnumerable<ConsultaDTO> listaConsultas = _consultaService.ObterTodasConsultas();
            IEnumerable<Pessoa> listaPessoas = _pessoaService.ObterTodos();
            ViewBag.Animais = new SelectList(listaAnimais, "IdAnimal", "Nome", null);
            ViewBag.Medicamentos = new SelectList(listaMedicamentos, "IdMedicamento", "Nome", null);
            ViewBag.Consultas = new SelectList(listaConsultas, "IdConsulta", "Descricao", null);
            ViewBag.Pessoas = new SelectList(listaPessoas, "IdPessoa", "Nome", null);
            return View();
        }

        // POST: AgendamedicamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Agendamedicamento agendamedicamentoModel)
        {
            if (ModelState.IsValid)
            {
                var agendamedicamento = _mapper.Map<Agendamedicamento>(agendamedicamentoModel);
                _agendamedicamentoService.Inserir(agendamedicamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AgendamedicamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            var frequencias = new[]
            {
                new SelectListItem { Value = "1", Text = "Diário" },
                new SelectListItem { Value = "2", Text = "Semanal" },
                new SelectListItem { Value = "3", Text = "Quinzenal" },
                new SelectListItem { Value = "4", Text = "Mensal" },
                new SelectListItem { Value = "5", Text = "Trimestral" },
                new SelectListItem { Value = "6", Text = "Semestral" },
                new SelectListItem { Value = "7", Text = "Anual" },
            };
            var intervalos = new[]
            {
                new SelectListItem { Value = "1", Text = "1x/dia" },
                new SelectListItem { Value = "2", Text = "2x/dia" },
                new SelectListItem { Value = "3", Text = "3x/dia" },
                new SelectListItem { Value = "4", Text = "4x/dia" },
                new SelectListItem { Value = "5", Text = "5x/dia" },
            };

            ViewBag.Frequencias = new SelectList(frequencias, "Value", "Text");
            ViewBag.Intervalos = new SelectList(intervalos, "Value", "Text");
            IEnumerable<Animal> listaAnimais = _animalService.ObterTodos();
            IEnumerable<MedicamentoDTO> listaMedicamentos = _medicamentoService.ObterTodos();
            IEnumerable<ConsultaDTO> listaConsultas = _consultaService.ObterTodasConsultas();
            IEnumerable<Pessoa> listaPessoas = _pessoaService.ObterTodos();
            Agendamedicamento agendamedicamento = _agendamedicamentoService.Obter(id);
            AgendamedicamentoModel agendamedicamentoModel = _mapper.Map<AgendamedicamentoModel>(agendamedicamento);
            ViewBag.Animais = new SelectList(listaAnimais, "IdAnimal", "Nome", null);
            ViewBag.Medicamentos = new SelectList(listaMedicamentos, "IdMedicamento", "Nome", null);
            ViewBag.Consultas = new SelectList(listaConsultas, "IdConsulta", "Descricao", null);
            ViewBag.Pessoas = new SelectList(listaPessoas, "IdPessoa", "Nome", null);
            return View(agendamedicamentoModel);
        }

        // POST: AgendamedicamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AgendamedicamentoModel agendamedicamentoModel)
        {
            if (ModelState.IsValid)
            {
                var agendamedicamento = _mapper.Map<Agendamedicamento>(agendamedicamentoModel);
                _agendamedicamentoService.Editar(agendamedicamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AgendamedicamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            Agendamedicamento agendamedicamento = _agendamedicamentoService.Obter(id);
            Medicamento medicamento = _medicamentoService.Obter(agendamedicamento.IdMedicamento);
            Animal animal = _animalService.Obter(agendamedicamento.IdAnimal);
            Consulta consulta = _consultaService.Obter(agendamedicamento.IdConsulta);
            Pessoa pessoa = _pessoaService.Obter(agendamedicamento.IdPessoa);
            ViewBag.Medicamento = medicamento.Nome;
            ViewBag.Animal = animal.Nome;
            ViewBag.Consulta = consulta.Descricao;
            ViewBag.Pessoa = pessoa.Nome;
            AgendamedicamentoModel agendamedicamentoModel = _mapper.Map<AgendamedicamentoModel>(agendamedicamento);
            return View(agendamedicamentoModel);
        }

        // POST: AgendamedicamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AgendamedicamentoModel agendamedicamentoModel)
        {
            _agendamedicamentoService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
