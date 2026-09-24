namespace Obligatorio.LogicaNegocio.Excepciones
{
    public class EmailInvalidoException : Exception
    {
        public EmailInvalidoException(string message) : base(message)
        {
        }
    }
}
