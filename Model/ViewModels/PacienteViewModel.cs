using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastrador_COVID_19.Model
{
    public class PacienteViewModel
    {
        public Paciente Pacientes { get; set; }
        public ICollection<LocalVacinacao> LocaisVacinacao { get; set; }

    }
}
