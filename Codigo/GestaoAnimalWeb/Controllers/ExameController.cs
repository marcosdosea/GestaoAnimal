using AutoMapper;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Collections.Generic;


namespace GestaoAnimalWeb.Controllers
{
    public class ExameController : Controller
    {
        IExameService _exameService;
        IConsultaService _consultaService;
        IAnimalService _animalService;
        ITipoexameService _tipoexameService;
        IMapper _mapper;

        public ExameController(IExameService exameService, IConsultaService consultaService, IAnimalService animalService, ITipoexameService tipoexameService, IMapper mapper)
        {
            _exameService = exameService;
            _consultaService = consultaService;
            _animalService = animalService;
            _tipoexameService = tipoexameService;
            _mapper = mapper;
        }

        // GET: ExameController
        public ActionResult Index()
        {
            var listaExames = _exameService.ObterTodos();
            return View(listaExames);
        }


        // GET: ExameController/Details/5
        public ActionResult Details(int id)
        {
            Exame exame = _exameService.Obter(id);
            Consulta consulta = _consultaService.Obter(exame.IdConsulta);
            Animal animal = _animalService.Obter(exame.IdAnimal);
            Tipoexame tipoExame = _tipoexameService.Obter(exame.IdTipoExame);

            ViewBag.IdConsulta = consulta.Descricao;
            ViewBag.IdAnimal = animal.Nome;
            ViewBag.IdTipoExame = tipoExame.Tipo;

            ExameModel exameModel = _mapper.Map<ExameModel>(exame);
            return View(exameModel);
        }

        // GET: ExameController/Create
        public ActionResult Create()
        {
            IEnumerable<Consulta> listaConsultas = _consultaService.ObterTodos();
            IEnumerable<Animal> listaAnimais = _animalService.ObterTodos();
            IEnumerable<Tipoexame> listaTipoexames = _tipoexameService.ObterTodos();

            ViewBag.IdConsulta = new SelectList(listaConsultas, "IdConsulta", "Descricao", null);
            ViewBag.IdAnimal = new SelectList(listaAnimais, "IdAnimal", "Nome", null);
            ViewBag.IdTipoExame = new SelectList(listaTipoexames, "IdTipoExame", "Tipo", null);
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
            IEnumerable<Consulta> listaConsultas = _consultaService.ObterTodos();
            IEnumerable<Animal> listaAnimais = _animalService.ObterTodos();
            IEnumerable<Tipoexame> listaTipoexames = _tipoexameService.ObterTodos();
            Exame exame = _exameService.Obter(id);

            ViewBag.IdConsulta = new SelectList(listaConsultas, "IdConsulta", "Descricao", null);
            ViewBag.IdAnimal = new SelectList(listaAnimais, "IdAnimal", "Nome", null);
            ViewBag.IdTipoExame = new SelectList(listaTipoexames, "IdTipoExame", "Tipo", null);
            
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
            Consulta consulta = _consultaService.Obter(exame.IdConsulta);
            Animal animal = _animalService.Obter(exame.IdAnimal);
            Tipoexame tipoExame = _tipoexameService.Obter(exame.IdTipoExame);

            ViewBag.IdConsulta = consulta.Descricao;
            ViewBag.IdAnimal = animal.Nome;
            ViewBag.IdTipoExame = tipoExame.Tipo;

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
