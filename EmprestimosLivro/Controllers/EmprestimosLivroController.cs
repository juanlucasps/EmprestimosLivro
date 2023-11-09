using EmprestimosLivro.Models;
using EmprestimosLivro.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EmprestimosLivro.Controllers
{
    public class EmprestimosLivroController : Controller
    {
        readonly private ApplicationDbContext _db;

        public EmprestimosLivroController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _db.EmprestimosLivro;
            return View(emprestimos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {
            if (ModelState.IsValid)
            {
                _db.EmprestimosLivro.Add(emprestimos);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.EmprestimosLivro.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.EmprestimosLivro.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }


            return View(emprestimo);

        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _db.EmprestimosLivro.Update(emprestimo);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimos) 
        { 
            if(emprestimos == null)
                return NotFound();

            _db.EmprestimosLivro.Remove(emprestimos);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
