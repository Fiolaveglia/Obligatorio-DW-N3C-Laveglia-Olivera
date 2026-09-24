using Obligatorio.LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Obligatorio.LogicaNegocio.Vo
{
    public record VoContrasenia
    {
        public string Valor { get; set; }

        public VoContrasenia(string valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {
            if (Valor.Length < 8)
            {
                throw new UsuarioInvalidoException("La contraseña debe tener al menos 8 caracteres");
            }

            if (!Regex.IsMatch(Valor, "[A-Z]"))
            {
                throw new UsuarioInvalidoException("La contraseña debe contener una mayuscula.");
            }

            if (!Regex.IsMatch(Valor, "[a-z]"))
            {
                throw new UsuarioInvalidoException("La contraseña debe contener una minuscula");
            }

            if (!Regex.IsMatch(Valor, "[0-9]"))
            {
                throw new UsuarioInvalidoException("La contraseña debe contener un numero");
            }

            if (!Regex.IsMatch(Valor, @"[^a-zA-Z0-9]"))
            {
                throw new UsuarioInvalidoException("La contraseña debe contener un caracter especial.");
            }

        }
    }
}
