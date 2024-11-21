using CapaBl;
using CapaDal;
using CapaEnt;
using CrudPersonas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudPersonas.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ListaPersonas()
        {

            List<ClsPersona> listaPersonas = ClsListadosBDBl.ObtenerLista();

            return View(listaPersonas);
        }

        public ActionResult VerPersona()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VerPersona(int id)
        {

            ClsPersona persona = new ClsPersona();
            try
            {
                persona = ClsServicesBDBl.BuscarPersonaBl(id);
            }
            catch
            {            
            }
            return View("VerPersona",persona);
        }

        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            ClsPersona persona = ClsServicesBDBl.BuscarPersonaBl(id);
            return View(persona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int FilasAfectadas = ClsServicesBDBl.DeletePersonaBl(id);
                return RedirectToAction(nameof(Index),FilasAfectadas);
            }
            catch
            {
                return View();
            }
        }
    }
}
