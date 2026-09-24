
namespace Obligatorio.LogicaNegocio.Entidades
{
    public class CapituloFinal : Capitulo
    {
        public int Contador { get; set; } = 0;

        protected CapituloFinal() { }

        public CapituloFinal(string titulo, string texto) : base(titulo, texto)
        {
            Validar();  
        }

        public void IncrementarContador()
        {
            Contador++;
        }

    }
}
