using Microsoft.EntityFrameworkCore;
using MVC_Crud_NET_8.Models;

namespace MVC_Crud_NET_8.Datos
{
        public class ApplicationDBContext : DbContext
        {
                public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
                {
                }

                //Agregar los modelos aqui
                
                public DbSet<Contacto> Contacto { get; set; }
        }
}
