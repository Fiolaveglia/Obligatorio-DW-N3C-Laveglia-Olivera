
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioCategoria
    {
        List<Categoria> ObtenerPorIds(List<int> ids);
        List<Categoria> Listar(); 
    }
}
