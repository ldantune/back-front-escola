using System.Net;

namespace Escola.Exceptions.ExceptionBase;
public class NotFoundException : EscolaException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override IList<string> GetErrorMessages() => [Message];

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
}
