using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioUsuario
    {
        void Add(Usuario usuario);

        bool ExisteUsuario(Usuario usuario);
        Usuario? BuscarPorCredenciales(string nombreUsuario, string contrasenia);
    }
}
