namespace Obligatorio.LogicaAplicacion.DTO
{
    public class DtoHistoriaAlta
    {
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public List<int> CategoriasIds { get; set; } = new List<int>();
        public string TituloCapituloInicial { get; set; }
        public string TextoCapituloInicial { get; set; } 

    }
}
