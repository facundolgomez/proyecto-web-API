using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Dueno> Duenos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Mascota> Mascotas { get; set; }

        public DbSet<Guarderia> Guarderias { get; set; }


        private readonly bool isTestingEnvironment;

        public ApplicationContext(DbContextOptions<ApplicationContext> options, bool isTestingEnvironment = false) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {
            this.isTestingEnvironment = isTestingEnvironment;
        }


    }
}
