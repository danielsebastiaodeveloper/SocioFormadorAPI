using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocioFormador.Application.DTOs
{
    public class ClienteDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; } = default!; //No puede ser nulo incluso si el tipo permite valor nulo.
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public long CiudadId { get; set; }
    }
}
