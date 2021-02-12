using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Collections.Generic;


namespace Controllers
{
    public class PessoaController : Controller
    {
        IPessoaService _pessoaService;
        IMapper _mapper;

        public PessoaController (IPessoaService pessoaService, IMapper mapper)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: PessoaController
        public ActionResult Index()
        {
            var listaPessoas = _pessoaService.ObterTodos();
            var listaPessoasModel = _mapper.Map<List<PessoaModel>>(listaPessoas);
            return View(listaPessoasModel);
 
        }

        // GET: PessoaController/Details/5
        public ActionResult Details(int id)
        {
            Pessoa pessoa = _pessoaService.Obter(id);
            PessoaModel pessoaModel = _mapper.Map<PessoaModel>(pessoa);
            return View(pessoaModel);
        }

        // GET: PessoaController/Create
        public ActionResult Create()
        {
            var generos = new[]
            {
                new SelectListItem { Value = "M", Text = "Masculino" },
                new SelectListItem { Value = "F", Text = "Feminino" },
                new SelectListItem { Value = "I", Text = "Gênero não Binário" },
            };  
            ViewBag.Generos = new SelectList(generos, "Value", "Text");
            var tipoPessoas = new[]
            {
                new SelectListItem { Value = "A", Text = "Administrador" },
                new SelectListItem { Value = "O", Text = "Organização" },
                new SelectListItem { Value = "V", Text = "Veterinário" },
                new SelectListItem { Value = "R", Text = "Dono" },
            };
            ViewBag.Tipo = new SelectList(tipoPessoas, "Value", "Text");

            return View();
        }

        // POST: PessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaModel pessoaModel)
        {
            if (ModelState.IsValid)
            {
                var pessoa = _mapper.Map<Pessoa>(pessoaModel);
                _pessoaService.Inserir(pessoa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PessoaController/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa pessoa = _pessoaService.Obter(id);
            PessoaModel pessoaModel = _mapper.Map<PessoaModel>(pessoa);
            var generos = new[]
            {
                new SelectListItem { Value = "M", Text = "Masculino" },
                new SelectListItem { Value = "F", Text = "Feminino" },
                new SelectListItem { Value = "I", Text = "Gênero não Binário" },
            };
            ViewBag.Generos = new SelectList(generos, "Value", "Text");
            var tipoPessoas = new[]
            {
                new SelectListItem { Value = "A", Text = "Administrador" },
                new SelectListItem { Value = "O", Text = "Organização" },
                new SelectListItem { Value = "V", Text = "Veterinário" },
                new SelectListItem { Value = "R", Text = "Dono" },
            };
            ViewBag.Tipo = new SelectList(tipoPessoas, "Value", "Text");
            return View(pessoaModel);
        }

        // POST: PessoaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PessoaModel pessoaModel)
        {
            if (ModelState.IsValid)
            {
                var pessoa = _mapper.Map<Pessoa>(pessoaModel);
                _pessoaService.Editar(pessoa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PessoaController/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa pessoa = _pessoaService.Obter(id);
            PessoaModel pessoaModel = _mapper.Map<PessoaModel>(pessoa);
            return View(pessoaModel);
        }

        // POST: PessoaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PessoaModel pessoaModel)
        {
            _pessoaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
