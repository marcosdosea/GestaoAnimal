using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using GestaoAnimalWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAnimalWeb.Controllers
{
    public class AnimalController : Controller
    {
        IAnimalService _animalService;
        IMapper _mapper;

        public AnimalController(IAnimalService animalService, IMapper mapper)
        {
            _animalService = animalService;
            _mapper = mapper;
        }
        // GET: AnimalController
        public ActionResult Index()
        {
            var listaAnimais = _animalService.ObterTodos();
            var listalistaAnimaisModel = _mapper.Map<List<AnimalModel>>(listaAnimais);
            return View(listalistaAnimaisModel);
        }

        // GET: AnimalController/Details/5
        public ActionResult Details(int id)
        {
            Animal animal = _animalService.Obter(id);
            AnimalModel animalModel = _mapper.Map<AnimalModel>(animal);
            return View(animalModel);
        }

        // GET: AnimalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnimalModel animalModel)
        {
            if (ModelState.IsValid)
            {
                var animal = _mapper.Map<Animal>(animalModel);
                _animalService.Inserir(animal);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AnimalController/Edit/5
        public ActionResult Edit(int id)
        {
            Animal animal = _animalService.Obter(id);
            AnimalModel animalModel = _mapper.Map<AnimalModel>(animal);
            return View(animalModel);
        }

        // POST: AnimalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AnimalModel animalModel)
        {
            if (ModelState.IsValid)
            {
                var animal = _mapper.Map<Animal>(animalModel);
                _animalService.Editar(animal);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AnimalController/Delete/5
        public ActionResult Delete(int id)
        {
            Animal animal = _animalService.Obter(id);
            AnimalModel animalModel = _mapper.Map<AnimalModel>(animal);
            return View(animalModel);
        }

        // POST: AnimalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AnimalModel animalModel)
        {
            _animalService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
