namespace Escola.Communication.Responses;
public class ResponseDisciplinaJson
{
    public long CodDisc { get; set; }
    public int QtdCred { get; set; }
    public string NomDisc { get; set; } = string.Empty;
    public long CodDiscEquiv { get; set; }
}
