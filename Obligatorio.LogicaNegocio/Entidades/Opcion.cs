
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Opcion : IValidable
    {
        public int Id { get; set; }
        public string Texto { get; set; } 
        public Capitulo Destino { get; set; }

        protected Opcion() { }

        public Opcion(string texto, Capitulo destino)
        {
            Texto = texto;
            Destino = destino;
            Validar();
        }

        public void Validar()
        {
            if(string.IsNullOrEmpty(Texto))
            {
                throw new OpcionInvalidaException("El texto de la opción no puede ser nulo o vacío.");
            }
            if(Destino == null)
            {
                throw new OpcionInvalidaException("El destino de la opción no puede ser nulo.");
            }
        }
    }

}
