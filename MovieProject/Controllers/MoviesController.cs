using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieProject.Controllers
{
    public class MoviesController : Controller
    {
        // GET
        public Task<IActionResult> Details(int id)
        {
            return View();
        }
    }
}