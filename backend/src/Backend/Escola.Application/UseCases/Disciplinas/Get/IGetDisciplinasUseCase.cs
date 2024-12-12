using Escola.Communication.Responses;

namespace Escola.Application.UseCases.Disciplinas.Get;
public interface IGetDisciplinasUseCase
{
    Task<ResponseDisciplinasJson> Execute();
}
