using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastrador_COVID_19.Model
{
    public class LocalVacinacao
    {
        public int Id { get; internal set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int QuantidadesVagas { get; set; }
        public int QuantidadesMaxVagas { get; set; }
        public DateTime dataVacinacao { get; set; }

        public ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
        

        public LocalVacinacao()
        {
        }

        public LocalVacinacao(int id, string nome, string endereco, int quantidadesVagas, DateTime dataVacinacao)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            QuantidadesVagas = quantidadesVagas;
            this.dataVacinacao = dataVacinacao;
        }

        public LocalVacinacao(int id, string nome, string endereco, int quantidadesVagas, DateTime dataVacinacao, ICollection<Paciente> pacientes)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            QuantidadesVagas = quantidadesVagas;
            this.dataVacinacao = dataVacinacao;
            Pacientes = pacientes;
        }

        public void AddPaciente(Paciente Paciente)
        {
            Pacientes.Add(Paciente);
        }

    }
}
