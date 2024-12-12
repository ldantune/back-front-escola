using Escola.Communication.Responses;
using Escola.Exceptions.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Escola.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is EscolaException dvdStoreException)
            HandleProjectException(dvdStoreException, context);
        else
            ThrowUnknowException(context);
    }

    private static void HandleProjectException(EscolaException dvdStoreException, ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)dvdStoreException.GetStatusCode();
        context.Result = new ObjectResult(new ResponseErrorJson(dvdStoreException.GetErrorMessages()));
    }

    private static void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson("Erro desconhecido"));
    }
}
