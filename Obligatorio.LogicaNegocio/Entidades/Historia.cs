using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesDominio;


namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Historia : IValidable
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public EstadoHistoria Estado { get; private set; } = EstadoHistoria.BORRADOR;
        public Capitulo CapituloInicial { get; set; }
        public List<Capitulo> Capitulos { get; set; } = new List<Capitulo>();
        public List<Categoria> Categorias { get; set; } = new List<Categoria>();

        protected Historia() { }

        public Historia(string titulo, string sinopsis, List<Categoria> categorias, string tituloCapituloInicial, string textoCapituloInicial)
        {
            Titulo = titulo;
            Sinopsis = sinopsis;
            Categorias = categorias;

            //la historia se crea con un capítulo CapituloInicial, que es un capítulo intermedio
            var capituloInicial = new CapituloIntermedio(tituloCapituloInicial, textoCapituloInicial);
            Capitulos.Add(capituloInicial);
            CapituloInicial = capituloInicial;
            Validar();
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Titulo))
            {
                throw new HistoriaInvalidaException("El título de la historia es obligatorio.");
            }
            if (string.IsNullOrEmpty(Sinopsis))
            {
                throw new HistoriaInvalidaException("La sinopsis de la historia es obligatoria.");
            }
            if (Categorias == null || Categorias.Count == 0)
            {
                throw new HistoriaInvalidaException("La historia debe tener al menos una categoría.");
            }
            if (CapituloInicial is CapituloFinal)
            {
                throw new HistoriaInvalidaException("La historia no puede comenzar con un capítulo final.");
            }
        }

        public void Publicar()
        {
            foreach (var capitulo in Capitulos)
            {
                if (capitulo is CapituloIntermedio intermedio && !intermedio.Opciones.Any())
                {
                    throw new HistoriaInvalidaException("Un capítulo intermedio debe tener al menos una opción.");
                }
            }
            Estado = EstadoHistoria.PUBLICADA;
        }

        public void VolverBorrador()
        {
            Estado = EstadoHistoria.BORRADOR;
        }

        public void ActualizarDatos(string titulo, string sinopsis, List<Categoria> categorias)
        {
            Titulo = titulo;
            Sinopsis = sinopsis;
            Categorias = categorias;
            Validar();
        }

        //El capitulo inicial se podrá modificar siempre y cuando no se hayan agregado otros capitulos a la historia.  
        public void EditarCapituloInicial(string titulo, string texto)
        {
            if (Capitulos.Count > 1)
            {
                throw new CapituloInvalidoException("No se puede modificar el capítulo inicial por que ya se han agregado otros capítulos a la historia.");
            }

            CapituloInicial.Titulo = titulo;
            CapituloInicial.Texto = texto;
            CapituloInicial.Validar();


        }
    }
}
