using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class UsuarioInvalidoException : Exception 
    {
        public UsuarioInvalidoException(string mensaje) : base(mensaje) 
        {
            
        }
    }
}
