using SocioFormador.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace SocioFormador.Application.DTOs;

public class PedidoDTO
{
    public long Id { get; set; }
    public long ClienteId { get; set; }
    public decimal Total { get; set; }
    public int Cantidad { get; set; }
}
