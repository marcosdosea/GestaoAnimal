using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core;
using AutoMapper;
using Models;
using System.Collections.Generic;

namespace Controllers
{
    public class AgendamedicamentoController : Controller
    {
        IAgendamedicamentoService _agendamedicamentoService;
        IMapper _mapper;

        public AgendamedicamentoController(IAgendamedicamentoService agendamedicamentoService, IMapper mapper)
        {
            _agendamedicamentoService = agendamedicamentoService;
            _mapper = mapper;
        }

        // GET: AgendamedicamentoController
        public ActionResult Index()
        {
            var listaAgendamento = _agendamedicamentoService.ObterTodos();
            var agendamedicamentoModel = _mapper.Map<List<AgendamedicamentoModel>>(listaAgendamento);
            return View(agendamedicamentoModel);
        }

        // GET: AgendamedicamentoController/Details/5
        public ActionResult Details(int id)
        {
            Agendamedicamento agendamedicamento = _agendamedicamentoService.Obter(id);
            AgendamedicamentoModel agendamedicamentoModel = _mapper.Map<AgendamedicamentoModel>(agendamedicamento);
            return View(agendamedicamentoModel);
        }

        // GET: AgendamedicamentoController/Create
        public ActionResult Create()
        {
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
            Agendamedicamento agendamedicamento = _agendamedicamentoService.Obter(id);
            AgendamedicamentoModel agendamedicamentoModel = _mapper.Map<AgendamedicamentoModel>(agendamedicamento);
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
