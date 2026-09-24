using Obligatorio.LogicaAplicacion.DTO;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Usuarios
{
    public class LoginUsuario
    {
        private IRepositorioUsuario _repo;

        public LoginUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public Usuario Ejecutar(DtoLogin dto)
        {
            Usuario? usuario = _repo.BuscarPorCredenciales(
                dto.NombreUsuario,
                dto.Contrasenia
            );

            if (usuario == null)
            {
                throw new UsuarioInvalidoException("Usuario o contraseña incorrectos");
            }

            if (usuario.Rol.Valor != "Administrador")
            {
                throw new UsuarioInvalidoException("Usuario o contraseña incorrectos");
            }

            return usuario;
        }
    }
}