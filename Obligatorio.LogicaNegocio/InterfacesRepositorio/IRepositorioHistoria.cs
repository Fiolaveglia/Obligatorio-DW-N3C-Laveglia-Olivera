using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioHistoria
    {
        void Add(Historia historia);
        void Update(Historia historia);
        Historia? ObtenerPorId(int id);
        List<Historia> Listar();
        bool TieneLecturas(int historiaId); //Comprueba que no tenga lecutras asociadas
        void Eliminar(Historia historia); 
    }
}
