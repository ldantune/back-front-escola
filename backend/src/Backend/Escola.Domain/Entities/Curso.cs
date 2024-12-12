namespace Escola.Domain.Entities;
public class Curso
{
    public int CodCurso { get; set; }
    public int TotCred { get; set; }
    public string NomCurso { get; set; } = string.Empty;
    public int CodCoord { get; set; }
}
