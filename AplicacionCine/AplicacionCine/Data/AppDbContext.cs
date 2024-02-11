using AplicacionCine.Models;
using Microsoft.EntityFrameworkCore;

namespace AplicacionCine.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {       
        
        
        }
        #region
        //En esta region se indica cuales son las tablas del modelo que el contexto usara para la base de datos. 
        #endregion
    }
}
