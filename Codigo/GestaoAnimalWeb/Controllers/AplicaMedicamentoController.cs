using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core;
using AutoMapper;
using Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace GestaoAnimalWeb.Controllers
{
    public class AplicaMedicamentoController : Controller
    {
        IAplicaMedicamentoService _aplicaMedicamentoService;
        IMedicamentoService _medicamentoService;
        IAnimalService _animalService;
        IPessoaService _pessoaService;
        IMapper _mapper;

        public AplicaMedicamentoController(IAplicaMedicamentoService aplicaMedicamentoService, 
            IMedicamentoService medicamentoService,
            IAnimalService animalService,
            IPessoaService pessoaService, 
            IMapper mapper)
        {
            _aplicaMedicamentoService = aplicaMedicamentoService;
            _medicamentoService = medicamentoService;
            _animalService = animalService;
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: AplicaMedicamento
        public ActionResult Index()
        {
            var listaAplicacaoMedicamento = _aplicaMedicamentoService.ObterTodos();
            return View(listaAplicacaoMedicamento);
        }

        // GET: AplicaMedicamento/Details/5
        public ActionResult Details(int id)
        {
            Aplicamedicamento aplicaMedicamento = _aplicaMedicamentoService.Obter(id);
            Medicamento medicamento = _medicamentoService.Obter(aplicaMedicamento.IdMedicamento);
            Animal animal = _animalService.Obter(aplicaMedicamento.IdAnimal);
            Pessoa pessoa = _pessoaService.Obter(aplicaMedicamento.IdPessoa);
            ViewBag.Medicamento = medicamento.Nome;
            ViewBag.Animal = animal.Nome;
            ViewBag.Pessoa = pessoa.Nome;
            AplicaMedicamentoModel aplicaMedicamentoModel = _mapper.Map<AplicaMedicamentoModel>(aplicaMedicamento);
            return View(aplicaMedicamentoModel);
        }

        // GET: AplicaMedicamento/Create
        public ActionResult Create()
        {
            IEnumerable<Animal> listaAnimais = _animalService.ObterTodos();
            IEnumerable<MedicamentoDTO> listaMedicamentos = _medicamentoService.ObterTodos();
            IEnumerable<Pessoa> listaPessoas = _pessoaService.ObterTodos();
            ViewBag.Animais = new SelectList(listaAnimais, "IdAnimal", "Nome", null);
            ViewBag.Medicamentos = new SelectList(listaMedicamentos, "IdMedicamento", "Nome", null);
            ViewBag.Pessoas = new SelectList(listaPessoas, "IdPessoa", "Nome", null);
            return View();
        }

        // POST: AplicaMedicamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AplicaMedicamentoModel aplicaMedicamentoModel)
        {
            if (ModelState.IsValid)
            {
                if (aplicaMedicamentoModel.DataAplicacao > DateTime.Now)
                {
                    Console.WriteLine("Erro: A data de aplicação não pode ser maior que a data de hoje.");
                }
                var aplicaMedicamento = _mapper.Map<Aplicamedicamento>(aplicaMedicamentoModel);
                _aplicaMedicamentoService.Inserir(aplicaMedicamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AplicaMedicamento/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<Animal> listaAnimais = _animalService.ObterTodos();
            IEnumerable<MedicamentoDTO> listaMedicamentos = _medicamentoService.ObterTodos();
            IEnumerable<Pessoa> listaPessoas = _pessoaService.ObterTodos();
            Aplicamedicamento aplicaMedicamento = _aplicaMedicamentoService.Obter(id);
            AplicaMedicamentoModel aplicaMedicamentoModel = _mapper.Map<AplicaMedicamentoModel>(aplicaMedicamento);
            ViewBag.Animais = new SelectList(listaAnimais, "IdAnimal", "Nome", null);
            ViewBag.Medicamentos = new SelectList(listaMedicamentos, "IdMedicamento", "Nome", null);
            ViewBag.Pessoas = new SelectList(listaPessoas, "IdPessoa", "Nome", null);
            return View(aplicaMedicamentoModel);
        }

        // POST: AplicaMedicamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AplicaMedicamentoModel aplicaMedicamentoModel)
        {
            if (ModelState.IsValid)
            {
                aplicaMedicamentoModel.IdPessoa = 2;
                var aplicaMedicamento = _mapper.Map<Aplicamedicamento>(aplicaMedicamentoModel);
                _aplicaMedicamentoService.Editar(aplicaMedicamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AplicaMedicamento/Delete/5
        public ActionResult Delete(int id)
        {
            Aplicamedicamento aplicaMedicamento = _aplicaMedicamentoService.Obter(id);
            Medicamento medicamento = _medicamentoService.Obter(aplicaMedicamento.IdMedicamento);
            Animal animal = _animalService.Obter(aplicaMedicamento.IdAnimal);
            Pessoa pessoa = _pessoaService.Obter(aplicaMedicamento.IdPessoa);
            ViewBag.Medicamento = medicamento.Nome;
            ViewBag.Animal = animal.Nome;
            ViewBag.Pessoa = pessoa.Nome;
            AplicaMedicamentoModel aplicaMedicamentoModel = _mapper.Map<AplicaMedicamentoModel>(aplicaMedicamento);
            return View(aplicaMedicamentoModel);
        }

        // POST: AplicaMedicamento/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AplicaMedicamentoModel aplicaMedicamentoModel)
        {
            _aplicaMedicamentoService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
