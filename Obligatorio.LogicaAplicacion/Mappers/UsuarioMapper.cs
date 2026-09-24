using Obligatorio.LogicaAplicacion.DTO;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.LogicaAplicacion.Mappers
{
    public static class UsuarioMapper
    {
        public static Usuario DesdeDto(DtoUsuarioAlta dto)
        {
            return new Usuario(
                dto.Nombre,
                new VoEmail(dto.Email),
                dto.NombreUsuario,
                new VoContrasenia(dto.Contrasenia),
                new VoRol(dto.Rol)
                );
        }
    }
}
