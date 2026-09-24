using Obligatorio.LogicaNegocio.Excepciones;

namespace Obligatorio.LogicaNegocio.Vo
{
    public record VoRol
    {
        public string Valor { get; set; }

        public VoRol(string valor)
        {
            Valor = valor;
            Validar();
        }
        private void Validar()
        {
            if (Valor != "Administrador" && Valor != "Usuario")
            {
                throw new RolInvalidoException("El rol debe ser Administrador o Usuario.");    
            }
        }
    }
}
