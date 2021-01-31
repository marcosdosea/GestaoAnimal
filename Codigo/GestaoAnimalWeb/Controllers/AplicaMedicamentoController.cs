using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core;
using AutoMapper;
using Models;
using System.Collections.Generic;

namespace GestaoAnimalWeb.Controllers
{
    public class AplicaMedicamentoController : Controller
    {
        IAplicaMedicamentoService _aplicaMedicamentoService;
        IMapper _mapper;

        public AplicaMedicamentoController(IAplicaMedicamentoService aplicaMedicamentoService, IMapper mapper)
        {
            _aplicaMedicamentoService = aplicaMedicamentoService;
            _mapper = mapper;
        }

        // GET: AplicaMedicamento
        public ActionResult Index()
        {
            var listaAplicacaoMedicamento = _aplicaMedicamentoService.ObterTodos();
            var aplicaMedicamentoModel = _mapper.Map<List<AplicaMedicamentoModel>>(listaAplicacaoMedicamento);
            return View(aplicaMedicamentoModel);
        }

        // GET: AplicaMedicamento/Details/5
        public ActionResult Details(int id)
        {
            Aplicamedicamento aplicaMedicamento = _aplicaMedicamentoService.Obter(id);
            AplicaMedicamentoModel aplicaMedicamentoModel = _mapper.Map<AplicaMedicamentoModel>(aplicaMedicamento);
            return View(aplicaMedicamentoModel);
        }

        // GET: AplicaMedicamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AplicaMedicamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AplicaMedicamentoModel aplicaMedicamentoModel)
        {
            if (ModelState.IsValid)
            {
                var aplicaMedicamento = _mapper.Map<Aplicamedicamento>(aplicaMedicamentoModel);
                _aplicaMedicamentoService.Inserir(aplicaMedicamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AplicaMedicamento/Edit/5
        public ActionResult Edit(int id)
        {
            Aplicamedicamento aplicaMedicamento = _aplicaMedicamentoService.Obter(id);
            AplicaMedicamentoModel aplicaMedicamentoModel = _mapper.Map<AplicaMedicamentoModel>(aplicaMedicamento);
            return View(aplicaMedicamentoModel);
        }

        // POST: AplicaMedicamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AplicaMedicamentoModel aplicaMedicamentoModel)
        {
            if (ModelState.IsValid)
            {
                var aplicaMedicamento = _mapper.Map<Aplicamedicamento>(aplicaMedicamentoModel);
                _aplicaMedicamentoService.Editar(aplicaMedicamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AplicaMedicamento/Delete/5
        public ActionResult Delete(int id)
        {
            Aplicamedicamento aplicaMedicamento = _aplicaMedicamentoService.Obter(id);
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
