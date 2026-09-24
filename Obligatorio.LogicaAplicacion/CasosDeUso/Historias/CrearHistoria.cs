using Obligatorio.LogicaAplicacion.DTO;
using Obligatorio.LogicaAplicacion.Mappers;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Historias
{
    public class CrearHistoria
    {
        private IRepositorioHistoria _repoHistoria; 
        private IRepositorioCategoria _repoCategoria;

        public CrearHistoria(IRepositorioHistoria repoHistoria, IRepositorioCategoria repoCategoria)
        {
            _repoHistoria = repoHistoria;
            _repoCategoria = repoCategoria;
        }
        public void Ejecutar(DtoHistoriaAlta dto)
        {
            if(dto.CategoriasIds == null || dto.CategoriasIds.Count == 0)
            {
                throw new HistoriaInvalidaException("La historia debe tener al menos una categoría.");
            }
            
            var categorias = _repoCategoria.ObtenerPorIds(dto.CategoriasIds);
            if (categorias.Count != dto.CategoriasIds.Distinct().Count())
            {
                throw new HistoriaInvalidaException("Una o más categorías de las seleccionadas no existen.");
            }

            var historias = HistoriaMapper.DesdeDto(dto, categorias);
            _repoHistoria.Add(historias);
        }
    }
}
