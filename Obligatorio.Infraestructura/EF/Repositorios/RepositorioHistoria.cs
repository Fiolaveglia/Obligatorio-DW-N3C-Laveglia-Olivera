
using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.Infraestructura.EF.Repositorios
{
    public class RepositorioHistoria : IRepositorioHistoria
    {
        private ObligatorioContext _context;

        public RepositorioHistoria(ObligatorioContext context)
        {
            _context = context;
        }
        public void Add(Historia historia)
        {
            _context.Historias.Add(historia);
            _context.SaveChanges();
        }

        public void Eliminar(Historia historia)
        {
            _context.Historias.Remove(historia);
            _context.SaveChanges();
        }

        public List<Historia> Listar()
        {
           return _context.Historias
                .Include(h => h.Categorias)
                .ToList();

        }

        public Historia? ObtenerPorId(int id)
        {
            return _context.Historias
                .Include (h => h.Categorias)
                .Include(h => h.CapituloInicial)
                .Include(h => h.Capitulos)
                .ThenInclude(c => ((CapituloIntermedio)c).Opciones)
                .ThenInclude(o => o.Destino)
                .FirstOrDefault(h => h.Id == id);
        }

        public bool TieneLecturas(int historiaId)
        {
            return false;
        }

        public void Update(Historia historia)
        {
            _context.Historias.Update(historia);
            _context.SaveChanges();
        }
    }
}
