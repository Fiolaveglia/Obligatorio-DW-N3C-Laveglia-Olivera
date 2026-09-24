using Obligatorio.LogicaNegocio.Excepciones;
using System.Text.RegularExpressions;

namespace Obligatorio.LogicaNegocio.Vo
{
    public record VoEmail
    {
        public string Email { get; set; }
    
        public VoEmail(string email)
        {
            Email = email;
            Validar(); 
        }
        
        private void Validar()
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new EmailInvalidoException("El correo electrónico es inválido.");
            }

            if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new EmailInvalidoException("Ingrese un correo electrónico válido. Ejemplo: nombre@dominio.com");
            }
        }

    }

}
