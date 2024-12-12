using Escola.Communication.Responses;

namespace Escola.Application.UseCases.Disciplinas.GetByCodDisc;
public interface IGetByCodDisciplinaUseCase
{
    Task<ResponseDisciplinaJson> Execute(long codDisc);
}
