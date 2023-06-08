using SocioFormador.Domain.Common.Abstractions;

namespace SocioFormador.Domain.Entities
{
    public class Pedido: AuditableEntityBase<long, long>
    {
        public long ClienteId { get; set; }
        public required string Producto { get; set; }
        public int Cantidad { get; set; }
    }
}