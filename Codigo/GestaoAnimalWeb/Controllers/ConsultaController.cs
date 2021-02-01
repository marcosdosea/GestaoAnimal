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
    public class ConsultaController : Controller
       
    {
        IConsultaService _consultaService;
        IMapper _mapper;
        // GET: ConsultaController

        public ConsultaController(IConsultaService consultaService, IMapper mapper)
        {
            _consultaService = consultaService;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            var listaConsultas = _consultaService.ObterTodos();
            var listaConsultasModel = _mapper.Map<List<ConsultaModel>>(listaConsultas);
            return View(listaConsultasModel);
        }

        // GET: ConsultaController/Details/5
        public ActionResult Details(int IdConsulta)
        {
            Consulta consulta = _consultaService.Obter(IdConsulta);
            ConsultaModel consultaModel = _mapper.Map<ConsultaModel>(consulta);
            return View(consultaModel);
        }

        // GET: ConsultaController/Create
        public ActionResult Create()
        {
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
