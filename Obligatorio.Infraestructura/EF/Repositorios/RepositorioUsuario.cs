using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.Infraestructura.EF.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ObligatorioContext _context;

        public RepositorioUsuario(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public bool ExisteUsuario(Usuario usuario)
        {
            return _context.Usuarios.Any(u => u.NombreUsuario == usuario.NombreUsuario);
        }

        public Usuario? BuscarPorCredenciales(string nombreUsuario, string contrasenia)
        {
            return _context.Usuarios.FirstOrDefault(
                u => u.NombreUsuario == nombreUsuario &&
                     u.Contrasenia.Valor == contrasenia
            );
        }
    }
}
