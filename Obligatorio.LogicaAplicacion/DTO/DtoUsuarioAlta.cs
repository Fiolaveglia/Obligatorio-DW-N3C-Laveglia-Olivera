using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.LogicaAplicacion.DTO
{
    public class DtoUsuarioAlta
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string Rol { get; set; }
    }
}
