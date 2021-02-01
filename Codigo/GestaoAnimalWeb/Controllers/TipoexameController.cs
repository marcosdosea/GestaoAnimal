using AutoMapper;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Collections.Generic;

namespace GestaoAnimalWeb.Controllers
{
    public class TipoexameController : Controller
    {
        ITipoexameService _tipoexameService;
        IMapper _mapper;

        public TipoexameController(ITipoexameService tipoexameService, IMapper mapper)
        {
            _tipoexameService = tipoexameService;
            _mapper = mapper;
        }
        // GET: TipoexameController
        public ActionResult Index()
        {
            var listaTiposExames = _tipoexameService.ObterTodos();
            var listaTiposExamesModel = _mapper.Map<List<TipoexameModel>>(listaTiposExames);
            return View(listaTiposExamesModel);
        }

        // GET: TipoexameController/Details/5
        public ActionResult Details(int id)
        {
            Tipoexame tipoExame = _tipoexameService.Obter(id);
            TipoexameModel tipoExameModel = _mapper.Map<TipoexameModel>(tipoExame);
            return View(tipoExameModel);
        }

        // GET: TipoexameController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoexameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoexameModel tipoExameModel)
        {
            if (ModelState.IsValid)
            {
                var tipoExame = _mapper.Map<Tipoexame>(tipoExameModel);
                _tipoexameService.Inserir(tipoExame);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipoexameController/Edit/5
        public ActionResult Edit(int id)
        {
            Tipoexame tipoExame = _tipoexameService.Obter(id);
            TipoexameModel tipoExameModel = _mapper.Map<TipoexameModel>(tipoExame);
            return View(tipoExameModel);
        }

        // POST: TipoexameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoexameModel tipoExameModel)
        {
            if (ModelState.IsValid)
            {
                var tipoExame = _mapper.Map<Tipoexame>(tipoExameModel);
                _tipoexameService.Editar(tipoExame);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TipoexameController/Delete/5
        public ActionResult Delete(int id)
        {
            Tipoexame tipoExame = _tipoexameService.Obter(id);
            TipoexameModel tipoExameModel = _mapper.Map<TipoexameModel>(tipoExame);
            return View(tipoExameModel);
        }

        // POST: TipoexameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TipoexameModel tipoExameModel)
        {
            _tipoexameService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
