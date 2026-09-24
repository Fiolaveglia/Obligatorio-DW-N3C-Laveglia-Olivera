using Obligatorio.LogicaAplicacion.DTO;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Historias
{
    public class EditarHistoria
    {
        private IRepositorioHistoria _repoHistoria;
        private IRepositorioCategoria _repoCategoria;

        public EditarHistoria(IRepositorioHistoria repoHistoria, IRepositorioCategoria repoCategoria)
        {
            _repoHistoria = repoHistoria;
            _repoCategoria = repoCategoria;
        }

        public void Ejecutar(int id, DtoEdicionHistoria dto)
        {
            var historia = _repoHistoria.ObtenerPorId(id);

            if (historia == null)
            {
                throw new HistoriaInvalidaException("La historia no existe.");
            }

            if (dto.CategoriasIds == null || dto.CategoriasIds.Count == 0)
            {
                throw new HistoriaInvalidaException("Debe seleccionar al menos una categoría.");
            }

            var categorias = _repoCategoria.ObtenerPorIds(dto.CategoriasIds);
            if (categorias.Count != dto.CategoriasIds.Distinct().Count())
            {
                throw new HistoriaInvalidaException("Una o más categorías seleccionadas no son válidas.");
            }

            historia.ActualizarDatos(dto.Titulo, dto.Sinopsis, categorias);

            if (!string.IsNullOrEmpty(dto.TituloCapituloInicial) || !string.IsNullOrEmpty(dto.TextoCapituloInicial))
            {
                historia.EditarCapituloInicial(dto.TituloCapituloInicial, dto.TextoCapituloInicial);
            }

            AplicarEstado(historia, dto.Estado);
            _repoHistoria.Update(historia);
        }

        private void AplicarEstado(Historia historia, string estado)
        {
            switch(estado)
            {
                case "Publicada":
                    historia.Publicar();
                    break;
                case "Borrador":
                    historia.VolverBorrador();
                    break;
                default:
                    throw new HistoriaInvalidaException("Estado de historia inválido.");
            }
        }
    
    
    
    
    
    
    
    
    
    }
}
