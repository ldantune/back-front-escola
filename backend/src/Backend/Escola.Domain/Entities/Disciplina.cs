using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Entities;
public class Disciplina
{
    public long CodDisc { get; set; }
    public int QtdCred { get; set; }
    public string NomDisc { get; set; } = string.Empty;
    public long CodDiscEquiv { get; set; }
}
