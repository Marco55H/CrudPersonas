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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClsPersona persona)
        {
            try
            {
                int FilasAfectadas = ClsServicesBDBl.AddPersonaBl(persona);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ClsPersona persona = ClsServicesBDBl.BuscarPersonaBl(id);
            return View(persona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClsPersona persona)
        {
            try
            {
                int FilasAfectadas = ClsServicesBDBl.ActualizarPersonaBl(persona);

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
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
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
