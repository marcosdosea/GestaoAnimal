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
            //IPessoaService pessoaService,
            IMapper mapper)
        {
            _agendamedicamentoService = agendamedicamentoService;
            _medicamentoService = medicamentoService;
            _animalService = animalService;
            _consultaService = consultaService;
            //_pessoaService = pessoaService;
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
            ViewBag.Medicamento = medicamento.Nome;
            ViewBag.Animal = animal.Nome;
            ViewBag.Consulta = consulta.Descricao;
            //Pessoa service não está implementada então não será póssível obter o nome diretamente
            //Pessoa pessoa = _pessoaService.Obter(agendamedicamento.IdPessoa);
            //ViewBag.Pessoa = pessoa.Nome;
            AgendamedicamentoModel agendamedicamentoModel = _mapper.Map<AgendamedicamentoModel>(agendamedicamento);
            return View(agendamedicamentoModel);
        }

        // GET: AgendamedicamentoController/Create
        public ActionResult Create()
        {
            IEnumerable<Animal> listaAnimais = _animalService.ObterTodos();
            IEnumerable<MedicamentoDTO> listaMedicamentos = _medicamentoService.ObterTodos();
            IEnumerable<Consulta> listaConsultas = _consultaService.ObterTodos();
            ViewBag.Animais = new SelectList(listaAnimais, "IdAnimal", "Nome", null);
            ViewBag.Medicamentos = new SelectList(listaMedicamentos, "IdMedicamento", "Nome", null);
            ViewBag.Consultas = new SelectList(listaConsultas, "IdConsulta", "Nome", null);
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
            IEnumerable<Animal> listaAnimais = _animalService.ObterTodos();
            IEnumerable<MedicamentoDTO> listaMedicamentos = _medicamentoService.ObterTodos();
            IEnumerable<Consulta> listaConsultas = _consultaService.ObterTodos();
            Agendamedicamento agendamedicamento = _agendamedicamentoService.Obter(id);
            AgendamedicamentoModel agendamedicamentoModel = _mapper.Map<AgendamedicamentoModel>(agendamedicamento);
            ViewBag.Animais = new SelectList(listaAnimais, "IdAnimal", "Nome", null);
            ViewBag.Medicamentos = new SelectList(listaMedicamentos, "IdMedicamento", "Nome", null);
            ViewBag.Consultas = new SelectList(listaConsultas, "IdConsulta", "Nome", null);
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
            ViewBag.Medicamento = medicamento.Nome;
            ViewBag.Animal = animal.Nome;
            ViewBag.Consulta = consulta.Descricao;
            //Pessoa service não está implementada então não será póssível obter o nome diretamente
            //Pessoa pessoa = _pessoaService.Obter(aplicaMedicamento.IdPessoa);
            //ViewBag.Pessoa = pessoa.Nome;
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
