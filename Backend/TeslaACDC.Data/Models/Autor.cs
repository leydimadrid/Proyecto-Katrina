using System;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Data;

public class Autor : BaseEntity<int>
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Peudonimos { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public string Pais { get; set; } = string.Empty;
    public string Nacionalidad { get; set; } = string.Empty;
    public bool isAlive { get; set; }
    public int FechaMuerte { get; set; }
    public string Idiomas { get; set; } = string.Empty;
    public string Generos { get; set; } = string.Empty;
    public string Biografia { get; set; } = string.Empty;
    public string Galardones { get; set; } = string.Empty;
    public bool isEnabled { get; set; }

}
