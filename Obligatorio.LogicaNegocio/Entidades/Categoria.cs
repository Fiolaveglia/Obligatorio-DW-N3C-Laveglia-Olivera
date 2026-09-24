using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesDominio;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Categoria : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        protected Categoria() { }

        public Categoria(string nombre)
        {
            Nombre = nombre;
            Validar();
        }

        public void Validar()
        {
            if(string.IsNullOrEmpty(Nombre))
            {
                throw new CategoriaInvalidaException("El nombre de la categoría es obligatorio.");
            }
        }
    }

}
