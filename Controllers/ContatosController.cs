using Microsoft.AspNetCore.Mvc;
using DavinTI.Models;
using System.Collections.Generic;
using System.Linq;

namespace DavinTI.Controllers
{
    public class ContatosController : Controller
    {
        private static List<Contato> contatos = new List<Contato>();
        private static int nextId = 1;

        public IActionResult Index()
        {
            return View(contatos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contato contato, List<string> telefones)
        {
            contato.Id = nextId++;
            contato.Telefones = telefones;
            contatos.Add(contato);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var contato = contatos.FirstOrDefault(c => c.Id == id);
            if (contato == null) return NotFound();
            return View(contato);
        }

        [HttpPost]
        public IActionResult Edit(Contato contato, List<string> telefones)
        {
            var existing = contatos.FirstOrDefault(c => c.Id == contato.Id);
            if (existing == null) return NotFound();

            existing.Nome = contato.Nome;
            existing.Idade = contato.Idade;
            existing.Telefones = telefones;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var contato = contatos.FirstOrDefault(c => c.Id == id);
            if (contato == null) return NotFound();
            return View(contato);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var contato = contatos.FirstOrDefault(c => c.Id == id);
            if (contato != null)
            {
                contatos.Remove(contato);
                LogService.RegistrarExclusao(contato);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Search(string nome, string telefone)
        {
            var result = contatos.Where(c =>
                (string.IsNullOrEmpty(nome) || c.Nome.Contains(nome)) &&
                (string.IsNullOrEmpty(telefone) || c.Telefones.Contains(telefone))
            ).ToList();
            return View(result);
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
