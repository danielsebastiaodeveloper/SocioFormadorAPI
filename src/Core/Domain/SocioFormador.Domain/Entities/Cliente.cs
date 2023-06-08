using SocioFormador.Domain.Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SocioFormador.Domain.Entities
{
    public class Cliente : AuditableEntityBase<long, long>
    {
        public string Nombre { get; set; } = default!; //No puede ser nulo incluso si el tipo permite valor nulo.
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public long CiudadId { get; set; }
    }
}
