using AutoMapper;
using Escola.Communication.Responses;
using Escola.Domain.Repositories.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Application.UseCases.Disciplinas.Get;
public class GetDisciplinasUseCase : IGetDisciplinasUseCase
{
    private readonly IMapper _mapper;
    private readonly IDisciplineReadOnlyRepository _disciplinaRepository;

    public GetDisciplinasUseCase(IMapper mapper, IDisciplineReadOnlyRepository disciplinaRepository)
    {
        _mapper = mapper;
        _disciplinaRepository = disciplinaRepository;
    }

    public async Task<ResponseDisciplinasJson> Execute()
    {
        var disciplinas = await _disciplinaRepository.GetAll();

        return new ResponseDisciplinasJson
        {
            Disciplinas = _mapper.Map<IList<ResponseDisciplinaJson>>(disciplinas)
        };
    }
}
