using Obligatorio.LogicaNegocio.Vo;
using System.Text.RegularExpressions;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesDominio;


namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Usuario : IValidable
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public VoEmail Email { get; set; }
        public string NombreUsuario { get; set; }
        public VoContrasenia Contrasenia { get; set; }
        public VoRol Rol { get; set; }

        protected Usuario()
        {
        }

        public Usuario(string nombre, VoEmail email, string nombreUsuario, VoContrasenia contrasenia, VoRol rol)
        {
            Nombre = nombre;
            Email = email;
            NombreUsuario = nombreUsuario;
            Contrasenia = contrasenia;
            Rol = rol;

            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new UsuarioInvalidoException("El nombre es obligatorio.");
            }
            
            
            if (string.IsNullOrEmpty(NombreUsuario))
            {
                throw new UsuarioInvalidoException("El nombre de usuario es obligatorio");
            }

            if (Contrasenia == null)
            {
                throw new ContraseniaInvalidaException("La contraseña es obligatoria");
            }

            if (Rol == null)
            {
                throw new RolInvalidoException("El rol es obligatorio");
            }

        }
    }
}
