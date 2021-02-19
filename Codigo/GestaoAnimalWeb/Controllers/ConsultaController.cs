﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using GestaoAnimalWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestaoAnimalWeb.Controllers
{
    public class ConsultaController : Controller
       
    {
        IConsultaService _consultaService;
        IAnimalService _animalService;
        IPessoaService _pessoaService;
        IMapper _mapper;
        // GET: ConsultaController

        public ConsultaController(IConsultaService consultaService, IMapper mapper, IAnimalService animalService, IPessoaService pessoaService)
        {
            _consultaService = consultaService;
            _mapper = mapper;
            _animalService = animalService;
            _pessoaService = pessoaService;
        }
        public ActionResult Index()
        {
            var listaConsultas = _consultaService.ObterTodasConsultas();

            return View(listaConsultas);
        }

        // GET: ConsultaController/Details/5
        public ActionResult Details(int id)
        {
            Consulta consulta = _consultaService.Obter(id);
            Animal animal = _animalService.Obter(consulta.IdAnimal);
            ViewBag.Animal = animal.Nome;
            Pessoa pessoa = _pessoaService.Obter(consulta.IdPessoa);
            ViewBag.Pessoa = pessoa.Nome;
            ConsultaModel consultaModel = _mapper.Map<ConsultaModel>(consulta);
            return View(consultaModel);
        }

        // GET: ConsultaController/Create
        public ActionResult Create()
        {
            IEnumerable<Animal> listaAnimais = _animalService.ObterTodos();
            ViewBag.Animal = new SelectList(listaAnimais, "IdAnimal", "Nome", null);
            IEnumerable<Pessoa> listaPessoas = _pessoaService.ObterTodos();
            ViewBag.Pessoa = new SelectList(listaPessoas, "IdPessoa", "Nome", null);
            return View();
        }

        // POST: ConsultaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConsultaModel consultaModel)
        {
            if (ModelState.IsValid)
            {
                var consulta = _mapper.Map<Consulta>(consultaModel);
                _consultaService.Inserir(consulta);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ConsultaController/Edit/5
        public ActionResult Edit(int id)
        {
            Consulta consulta = _consultaService.Obter(id);
            ConsultaModel consultaModel = _mapper.Map<ConsultaModel>(consulta);

            IEnumerable<Animal> listaAnimais = _animalService.ObterTodos();
            IEnumerable<ConsultaDTO> listaConsultas = _consultaService.ObterTodasConsultas();
            ViewBag.Animal = new SelectList(listaAnimais, "IdAnimal", "Nome", null);
            IEnumerable<Pessoa> listaPessoas = _pessoaService.ObterTodos();
            ViewBag.Pessoa = new SelectList(listaPessoas, "IdPessoa", "Nome", null);
            return View(consultaModel);
          
        }

        // POST: ConsultaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ConsultaModel consultaModel)
        {
            if (ModelState.IsValid)
            {
                var consulta = _mapper.Map<Consulta>(consultaModel);
                _consultaService.Editar(consulta);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ConsultaController/Delete/5
        public ActionResult Delete(int id)
        {
            Consulta consulta = _consultaService.Obter(id);
            ConsultaModel consultaModel = _mapper.Map<ConsultaModel>(consulta);
            Animal animal = _animalService.Obter(consulta.IdAnimal);
            ViewBag.Animal = animal.Nome;
            Pessoa pessoa = _pessoaService.Obter(consulta.IdPessoa);
            ViewBag.Pessoa = pessoa.Nome;
            return View(consultaModel);
        }

        // POST: ConsultaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ConsultaModel consultaModel)
        {
            _consultaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
