using System;

namespace TeslaACDC.Data.Models;

public class Libros : BaseEntity<int>
{
    public string Título { get; set; } = string.Empty;
    public string ISBN13 { get; set; } = String.Empty;
    public string Editorial { get; set; } = String.Empty;
    public int AñoDePublicación { get; set; }
    public string Formato { get; set; } = String.Empty;
    public string Genero { get; set; } = String.Empty;
    public string Idioma { get; set; } = String.Empty;
    public string Portada { get; set; } = String.Empty;
    public string Edición { get; set; } = String.Empty;
    public string ContraPortada { get; set; } = String.Empty;
    public int AuthorID { get; set; }
}
