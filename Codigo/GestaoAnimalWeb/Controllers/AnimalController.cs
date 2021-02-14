using System;
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
    public class AnimalController : Controller
    {
        IAnimalService _animalService;
        IEspecieAnimalService _especieAnimalService;
        IPessoaService _pessoaService;
        IOrganizacaoService _organizacaoService;
        IMapper _mapper;
        //IOrganizacaoService _organizacaoService;


        public AnimalController(IAnimalService animalService, IEspecieAnimalService especieAnimalService, IPessoaService pessoaService, IOrganizacaoService organizacaoService, IMapper mapper)
        {
            _animalService = animalService;
            _especieAnimalService = especieAnimalService;
            _pessoaService = pessoaService;
            _organizacaoService = organizacaoService;
            _mapper = mapper;
        }
        // GET: AnimalController
        public ActionResult Index()
        {
            var listaAnimais = _animalService.ObterTodosAnimais();

            return View(listaAnimais);
        }

        // GET: AnimalController/Details/5
        public ActionResult Details(int id)
        {
            Animal animal = _animalService.Obter(id);
            Especieanimal especie = _especieAnimalService.Obter(animal.IdEspecieAnimal);
            Pessoa pessoa = _pessoaService.Obter(animal.IdPessoa);
            ViewBag.Pessoa = pessoa.Nome;
            Organizacao organizacao = _organizacaoService.Obter(animal.IdOrganizacao);
            ViewBag.EspecieAnimal = especie.Nome;
            ViewBag.Organizacao = organizacao.Nome;
            AnimalModel animalModel = _mapper.Map<AnimalModel>(animal);
            return View(animalModel);
        }

        // GET: AnimalController/Create
        public ActionResult Create()
        {
            IEnumerable<Especieanimal> listaEspecies = _especieAnimalService.ObterTodos();
            ViewBag.EspecieAnimal = new SelectList(listaEspecies, "IdEspecieAnimal", "Nome", null);

            IEnumerable<OrganizacaoDTO> listaOrganizacoes = _organizacaoService.ObterTodos();
            ViewBag.Organizacao = new SelectList(listaOrganizacoes, "IdOrganizacao", "Nome", null);

            IEnumerable<Pessoa> listaPessoas = _pessoaService.ObterTodos();
            ViewBag.Pessoa = new SelectList(listaPessoas, "IdPessoa", "Nome", null);
            var generos = new[]
            {
                new SelectListItem { Value = "M", Text = "Masculino" },
                new SelectListItem { Value = "F", Text = "Feminino" },

            };
            ViewBag.Generos = new SelectList(generos, "Value", "Text");
            IEnumerable<Pessoa> listaPessoas = _pessoaService.ObterTodos();
            ViewBag.Pessoa = new SelectList(listaPessoas, "IdPessoa", "Nome", null);

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
            IEnumerable<Especieanimal> listaEspecies = _especieAnimalService.ObterTodos();
            ViewBag.EspecieAnimal = new SelectList(listaEspecies, "IdEspecieAnimal", "Nome", null);
            IEnumerable<Pessoa> listaPessoas = _pessoaService.ObterTodos();
            ViewBag.Pessoa = new SelectList(listaPessoas, "IdPessoa", "Nome", null);
            IEnumerable<OrganizacaoDTO> listaOrganizacoes = _organizacaoService.ObterTodos();
            ViewBag.Organizacao = new SelectList(listaOrganizacoes, "IdOrganizacao", "Nome", null);
            
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

            Especieanimal especie = _especieAnimalService.Obter(animal.IdEspecieAnimal);
            ViewBag.EspecieAnimal = especie.Nome;

            Pessoa pessoa = _pessoaService.Obter(animal.IdPessoa);
            ViewBag.Pessoa = pessoa.Nome;

            Organizacao organizacao = _organizacaoService.Obter(animal.IdPessoa);
            ViewBag.Organizacao = organizacao.Nome;
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
