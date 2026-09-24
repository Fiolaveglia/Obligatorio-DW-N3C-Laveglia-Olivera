using Obligatorio.LogicaAplicacion.DTO;
using Obligatorio.LogicaAplicacion.Mappers;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Usuarios
{
    public class AltaUsuario
    {
        private IRepositorioUsuario _repo;

        public AltaUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;   
        }

        public void Ejecutar(DtoUsuarioAlta dto)
        {
            Usuario usuario = UsuarioMapper.DesdeDto(dto);

            if (_repo.ExisteUsuario(usuario))
            {
                throw new UsuarioInvalidoException("El Usuario ya existe");
            }

            _repo.Add(usuario);
        }
    }
}
