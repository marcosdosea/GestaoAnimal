using AutoMapper;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;


namespace GestaoAnimalWeb.Controllers
{
    public class ExameController : Controller
    {
        IExameService _exameService;
        IMapper _mapper;

        public ExameController(IExameService exameService, IMapper mapper)
        {
            _exameService = exameService;
            _mapper = mapper;
        }

        // GET: ExameController
        public ActionResult Index()
        {
            var listaExames = _exameService.ObterTodos();
            var examesModel = _mapper.Map<List<ExameModel>>(listaExames);
            return View(examesModel);
        }

        // GET: ExameController/Details/5
        public ActionResult Details(int id)
        {
            Exame exame = _exameService.Obter(id);
            ExameModel exameModel = _mapper.Map<ExameModel>(exame);
            return View(exameModel);
        }

        // GET: ExameController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExameModel exameModel)
        {
            if (ModelState.IsValid)
            {
                var exame = _mapper.Map<Exame>(exameModel);
                _exameService.Inserir(exame);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ExameController/Edit/5
        public ActionResult Edit(int id)
        {
            Exame exame = _exameService.Obter(id);
            ExameModel exameModel = _mapper.Map<ExameModel>(exame);
            return View(exameModel);
        }

        // POST: ExameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ExameModel exameModel)
        {
            if (ModelState.IsValid)
            {
                var exame = _mapper.Map<Exame>(exameModel);
                _exameService.Editar(exame);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: ExameController/Delete/5
        public ActionResult Delete(int id)
        {
            Exame exame = _exameService.Obter(id);
            ExameModel exameModel = _mapper.Map<ExameModel>(exame);
            return View(exameModel);
        }

        // POST: ExameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ExameModel exameModel)
        {
            _exameService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
