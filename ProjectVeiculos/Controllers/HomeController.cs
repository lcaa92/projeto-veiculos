using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using ProjectVeiculos.Models;
using System.IO;

namespace ProjectVeiculos.Controllers
{
    public class HomeController : Controller
    {
        private VeiculosDBEntities db = new VeiculosDBEntities();
        //
        // GET: /Home/

        public ActionResult Index(string mensagem)
        {
            var veiculos = db.veiculos.Include("tipos_veiculo").ToList();
            @ViewBag.messagem = mensagem;
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

        public ActionResult add_foto(long id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult add_foto(fotos_veiculo foto)
        {
            if (Request.Files.Count == 0)
            {
                return RedirectToAction("index");
            }
            if (ModelState.IsValid)
            {
                

                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                        file.SaveAs(path);
                        foto.arquivo = fileName;
                        db.fotos_veiculo.Add(foto);
                        db.SaveChanges();
                    }

                    
                }
                
                return RedirectToAction("index");
            }
            @ViewBag.id = foto.id_veiculo;
            return View(foto);
        }
    }
}
