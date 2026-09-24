using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public abstract class Capitulo : IValidable
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
       
        
        protected Capitulo() { }

        protected Capitulo(string titulo, string texto)
        {
            Titulo = titulo;
            Texto = texto;
            Validar();
        }
        public void Validar()
        {
            if(string.IsNullOrEmpty(Titulo))
            {
                throw new CapituloInvalidoException("El título del capítulo es obligatorio.");
            }
            if(string.IsNullOrEmpty(Texto))
            {
                throw new CapituloInvalidoException("El texto del capítulo es obligatorio.");
            }
        }
    }
}
