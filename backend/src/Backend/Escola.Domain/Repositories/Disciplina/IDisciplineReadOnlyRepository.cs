using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Repositories.Disciplina;
public interface IDisciplineReadOnlyRepository
{
    Task<IList<Entities.Disciplina>> GetAll();
    Task<Entities.Disciplina> GetByCodDisciplina(long codDisc);
}
