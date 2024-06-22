using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Usuario? UsuarioPorNombreUsuario(string nombreUsuario)
        {
            return _context.Set<Usuario>().FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
        }
    }
}
