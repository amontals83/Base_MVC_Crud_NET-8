using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Crud_NET_8.Datos;
using MVC_Crud_NET_8.Models;
using System.Diagnostics;

namespace MVC_Crud_NET_8.Controllers
{
        public class InicioController : Controller
        {      
                private readonly ApplicationDBContext _contexto; // Para acceder a la BBDD, llamando a los modelos registrados en ApplicationDbContext

                public InicioController(ApplicationDBContext contexto)
                {
                        _contexto = contexto; // Con esto ya estamos listos para utilizarlo en todos los metodos
                }

                [HttpGet]
                public async Task<IActionResult> Index()
                {
                        return View( await _contexto.Contacto.ToArrayAsync() );
                }

                [HttpGet]
                public IActionResult Crear()
                {
                        return View();
                }

                [HttpPost]
                [ValidateAntiForgeryToken] // Anti ataque XSS
                public async Task<IActionResult> Crear(Contacto contacto)
                {
                        if (ModelState.IsValid) //ModelSate mira a los Required de las variables en el modelo
                        {
                                contacto.FechaCreacion = DateTime.Now;
                                _contexto.Contacto.Add(contacto);
                                await _contexto.SaveChangesAsync();
                                //return RedirectToAction("Index");
                                return RedirectToAction(nameof (Index));
                        }
                        return View();
                }

                [HttpGet]
                public IActionResult Editar(int? id)
                {
                        if (id == null)
                        {
                                return NotFound();
                        }
                        var contacto = _contexto.Contacto.Find(id);
                        if (contacto == null)
                        {
                                return NotFound();
                        }
                        return View(contacto);
                }

                [HttpPost]
                [ValidateAntiForgeryToken] // Anti ataque XSS
                public async Task<IActionResult> Editar(Contacto contacto)
                {
                        if (ModelState.IsValid) //ModelSate mira a los Required de las variables en el modelo
                        {
                                _contexto.Update(contacto);
                                await _contexto.SaveChangesAsync();
                                //return RedirectToAction("Index");
                                return RedirectToAction(nameof(Index));
                        }
                        return View();
                }

                [HttpGet]
                public IActionResult Detalle(int? id)
                {
                        if (id == null)
                        {
                                return NotFound();
                        }
                        var contacto = _contexto.Contacto.Find(id);
                        if (contacto == null)
                        {
                                return NotFound();
                        }
                        return View(contacto);
                }

                [HttpGet]
                public IActionResult Borrar(int? id)
                {
                        if (id == null)
                        {
                                return NotFound();
                        }
                        var contacto = _contexto.Contacto.Find(id);
                        if (contacto == null)
                        {
                                return NotFound();
                        }
                        return View(contacto);
                }

                [HttpPost, ActionName("Borrar")] // Se utiliza para poder cambiar el nombre del método y asi mirar directamente al "asp-action" de la vista
                [ValidateAntiForgeryToken] // Anti ataque XSS
                public async Task<IActionResult> BorrarContacto(int? id)
                {
                        var contacto = await _contexto.Contacto.FindAsync(id);
                        if (contacto == null)
                        {
                                return View();
                        }
                        _contexto.Contacto.Remove(contacto);
                        await _contexto.SaveChangesAsync();

                        return RedirectToAction(nameof(Index));
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
