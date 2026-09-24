
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.Infraestructura.EF.Repositorios
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        private ObligatorioContext _context;

        public RepositorioCategoria(ObligatorioContext context)
        {
            _context = context;
        }

        public List<Categoria> ObtenerPorIds(List<int> ids)
        {
            return _context.Categorias
                .Where(c => ids.Contains(c.Id)).ToList();
        }
        public List<Categoria> Listar()
        {
            return _context.Categorias.ToList();
        }
    }
}
