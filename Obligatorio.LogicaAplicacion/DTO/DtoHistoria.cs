
namespace Obligatorio.LogicaAplicacion.DTO
{
   public class DtoHistoria
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string Estado { get; set; }
        public List<string> Categorias { get; set; } = new List<string>();
     }
}
