using System.Net;

namespace Escola.Exceptions.ExceptionBase;
public abstract class EscolaException : SystemException
{
    public EscolaException(string message) : base(message) { }

    public abstract IList<string> GetErrorMessages();
    public abstract HttpStatusCode GetStatusCode();
}
