using EmprestimosLivro.Models;
using EmprestimosLivro.Data;
using Microsoft.AspNetCore.Mvc;

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
    }
}
