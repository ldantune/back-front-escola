using AutoMapper;
using Escola.Communication.Responses;
using Escola.Domain.Repositories.Disciplina;
using Escola.Exceptions.ExceptionBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Application.UseCases.Disciplinas.GetByCodDisc;
public class GetByCodDisciplinaUseCase : IGetByCodDisciplinaUseCase
{
    private readonly IMapper _mapper;
    private readonly IDisciplineReadOnlyRepository _disciplinaRepository;

    public GetByCodDisciplinaUseCase(IMapper mapper, IDisciplineReadOnlyRepository disciplinaRepository)
    {
        _mapper = mapper;
        _disciplinaRepository = disciplinaRepository;
    }
    public async Task<ResponseDisciplinaJson> Execute(long codDisc)
    {
        var disciplina = await _disciplinaRepository.GetByCodDisciplina(codDisc);

        if(disciplina is null)
            throw new NotFoundException("Disciplina não encontrada");

        var response = _mapper.Map<ResponseDisciplinaJson>(disciplina);

        return response;
    }
}
