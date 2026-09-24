
using Obligatorio.LogicaAplicacion.DTO;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using System.Net.NetworkInformation;

namespace Obligatorio.LogicaAplicacion.Mappers
{
    public static class HistoriaMapper
    {
        public static Historia DesdeDto(DtoHistoriaAlta dto, List<Categoria> categorias)
        {
            return new Historia(
                dto.Titulo,
                dto.Sinopsis,
                categorias, 
                dto.TituloCapituloInicial, 
                dto.TextoCapituloInicial
            );
        }

        public static DtoHistoria ADto(Historia historia)
        {
            return new DtoHistoria
            {
                Id = historia.Id,
                Titulo = historia.Titulo,
                Sinopsis = historia.Sinopsis,
                Estado = historia.Estado.ToString(),
                Categorias = historia.Categorias.Select(c => c.Nombre).ToList()
            };
        }

    }
}
