
using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class CapituloIntermedio : Capitulo
    {
        public List<Opcion> Opciones { get; set; } = new();

        protected CapituloIntermedio() { }
        public CapituloIntermedio(string titulo, string texto) : base(titulo, texto)
        {
            Validar();
        }

        public void AgregarOpcion(string texto, Capitulo destino)
        {
            if (destino == this)
            {
                throw new OpcionInvalidaException("Una opcion no puede llevar al mismo capítulo.");
            }
            Opciones.Add(new Opcion(texto, destino));
        }
    }
}