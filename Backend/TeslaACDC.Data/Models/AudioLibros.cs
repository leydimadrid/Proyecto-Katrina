using System;

namespace TeslaACDC.Data.Models;

public class AudioLibros : BaseEntity<int>
{
    public string Titulo { get; set; } = string.Empty;
    public string AuthorId { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public int NarradorId { get; set; }
    public int Duracion { get; set; }
    public int Tamaño { get; set; }
    public string Path { get; set; } = string.Empty;
}
