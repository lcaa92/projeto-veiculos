using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using ProjectVeiculos.Models;

namespace ProjectVeiculos.Controllers
{
    public class HomeController : Controller
    {
        private VeiculosDBEntities db = new VeiculosDBEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var veiculos = db.veiculos.Include("tipos_veiculo").ToList();
            return View(veiculos);
        }

        public ActionResult Adicionar()
        {
            ViewBag.id_tipo_veiculo = new SelectList(db.tipos_veiculo, "id_tipo_veiculo", "nome");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(veiculos veiculo)
        {
            if (ModelState.IsValid)
            {
                db.veiculos.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.id_tipo_veiculo = new SelectList(db.tipos_veiculo, "id_tipo_veiculo", "nome");
            return View(veiculo);
        }

        public ActionResult Editar(long id)
        {
            veiculos veiculo = db.veiculos.Find(id);
            ViewBag.id_tipo_veiculo = new SelectList(db.tipos_veiculo, "id_tipo_veiculo", "nome", veiculo.id_tipo_veiculo);

            return View(veiculo);
        }

        [HttpPost]
        public ActionResult Editar(veiculos veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.id_tipo_veiculo = new SelectList(db.tipos_veiculo, "id_tipo_veiculo", "nome", veiculo.id_tipo_veiculo);

            return View(veiculo);
        }

        public ActionResult Excluir(long id)
        {
            try
            {
                veiculos veiculo = db.veiculos.Find(id);
                db.veiculos.Remove(veiculo);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult Visualizar(long id)
        {
            veiculos veiculo = db.veiculos.Find(id);
            return View(veiculo);
        }
    }
}
