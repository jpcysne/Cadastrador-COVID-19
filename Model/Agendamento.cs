using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastrador_COVID_19.Model
{
    public class Agendamento
    {
        public int Id { get; set; }

        public Paciente Paciente { get; set; }
        public LocalVacinacao LocalVacinacao { get; set; }

        public Agendamento()
        {
        }

        public Agendamento(int id, Paciente paciente, LocalVacinacao localVacinacao)
        {
            Id = id;
            Paciente = paciente;
            LocalVacinacao = localVacinacao;
        }
    }
}
