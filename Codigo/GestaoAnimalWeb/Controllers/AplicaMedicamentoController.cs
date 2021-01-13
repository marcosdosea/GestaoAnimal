using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core;
using AutoMapper;

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
            return View();
        }

        // GET: AplicaMedicamento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AplicaMedicamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AplicaMedicamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AplicaMedicamento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AplicaMedicamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AplicaMedicamento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AplicaMedicamento/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
