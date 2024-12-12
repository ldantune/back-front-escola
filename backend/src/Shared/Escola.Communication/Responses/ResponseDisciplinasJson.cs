using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Communication.Responses;
public class ResponseDisciplinasJson
{
    public IList<ResponseDisciplinaJson> Disciplinas { get; set; } = [];
}
