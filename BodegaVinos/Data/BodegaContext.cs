using BodegaVinos.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodegaVinos.Data
{

    public class BodegaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Wine> Wines {  get; set; }

        public DbSet<Cata> Catas { get; set; }


        public BodegaContext(DbContextOptions<BodegaContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }
    }
}
