using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Morador : Pessoa
    {
        public string DataEntrada { get; set; }
        public string DataSaida { get; set; }

        public Morador() { }
        public Morador(string dataEntrada, string dataSaida, int statusMoradia, 
            int codigo, string nome, string rg, string cpf, string telefone, string endereco, string email, string usuario, string senha, bool statusBD)
            : base(codigo, nome, rg, cpf, telefone, endereco, email, usuario, senha)
        {
            DataEntrada = dataEntrada;
            DataSaida = DataSaida;
        }
    }
}
