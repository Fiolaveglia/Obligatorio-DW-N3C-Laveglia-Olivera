
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Historias
{
    public class BajaHistoria
    {
        private IRepositorioHistoria _repo; 

        public BajaHistoria(IRepositorioHistoria repo)
        {
            _repo = repo;
        }

        public void Ejecutar(int id)
        {
            var historia = _repo.ObtenerPorId(id);
            
            if (historia == null)
            {
                throw new HistoriaInvalidaException("La historia no existe.");
            }

            if(_repo.TieneLecturas(id))
            {
                throw new HistoriaInvalidaException("La historia no puede ser eliminada porque tiene lecturas asociadas.");
            }

            _repo.Eliminar(historia);
        }
    }
}
