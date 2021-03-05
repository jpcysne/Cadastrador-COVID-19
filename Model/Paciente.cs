using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Cadastrador_COVID_19.Model.Enum.Enum;

namespace Cadastrador_COVID_19.Model
{
    public class Paciente
    {


        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DatadeNascimento { get; set; }
        public LocalVacinacao Local { get; set; }

        public Paciente()
        {
        }

        public Paciente(int id, string nome, string endereco, DateTime datadeNascimento, LocalVacinacao local)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            DatadeNascimento = datadeNascimento;
            Local = local;
        }
    }
}
