using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Crud_NET_8.Datos;
using MVC_Crud_NET_8.Models;
using System.Diagnostics;

namespace MVC_Crud_NET_8.Controllers
{
        public class InicioController : Controller
        {      
                private readonly ApplicationDBContext _contexto;

                public InicioController(ApplicationDBContext contexto)
                {
                        _contexto = contexto;
                }

                public async Task<IActionResult> Index()
                {
                        return View( await _contexto.Contacto.ToArrayAsync() );
                }

                public IActionResult Privacy()
                {
                        return View();
                }

                [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
                public IActionResult Error()
                {
                        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
        }
}
