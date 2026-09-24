namespace Obligatorio.LogicaAplicacion.DTO
{
    public class DtoEdicionHistoria
    {
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public List<int> CategoriasIds { get; set; } = new List<int>();
        public string Estado { get; set; }
        public string? TituloCapituloInicial { get; set; }
        public string? TextoCapituloInicial { get; set; }
    }
}
