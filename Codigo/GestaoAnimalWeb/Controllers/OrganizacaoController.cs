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
    public class OrganizacaoController : Controller
    {
        IOrganizacaoService _organizacaoService;
        IMapper _mapper;

        public OrganizacaoController(IOrganizacaoService organizacaoService, IMapper mapper)
        {
            
             _organizacaoService = organizacaoService;
            _mapper = mapper;
        }

        // GET: OrganizacaoController
        public ActionResult Index()

        {
            var listaOrganizacoes = _organizacaoService.ObterTodos();

            return View(listaOrganizacoes);
            
        }

        // GET: OrganizacaoController/Details/5
        public ActionResult Details(int id)
        {
            Organizacao organizacao = _organizacaoService.Obter(id);
            
            ViewBag.Organizacao = organizacao.Nome;
            OrganizacaoModel organizacaoModel = _mapper.Map<OrganizacaoModel>(organizacao);
            return View(organizacaoModel);
           
        }

        // GET: OrganizacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganizacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrganizacaoModel organizacaoModel)
        {
            if (ModelState.IsValid)
            {
                var organizacao = _mapper.Map<Organizacao>(organizacaoModel);
                _organizacaoService.Inserir(organizacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OrganizacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            Organizacao organizacao = _organizacaoService.Obter(id);
            OrganizacaoModel organizacaoModel = _mapper.Map<OrganizacaoModel>(organizacao);
            return View(organizacaoModel);
        }

        // POST: OrganizacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrganizacaoModel organizacaoModel)
        {
            if (ModelState.IsValid)
            {
                var organizacao = _mapper.Map<Organizacao>(organizacaoModel);
                _organizacaoService.Editar(organizacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OrganizacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            Organizacao organizacao = _organizacaoService.Obter(id);
            OrganizacaoModel organizacaoModel = _mapper.Map<OrganizacaoModel>(organizacao);
            return View(organizacaoModel);
        }

        // POST: OrganizacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrganizacaoModel organizacaoModel)
        {
            _organizacaoService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
