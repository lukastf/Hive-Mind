using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Funcionario : Pessoa
    {
        public string DataAdmissao { get; set; }
        public string DataDemissao { get; set; }
        public bool StatusAdmin { get; set; }

        public Funcionario() { }
        public Funcionario(string dataAdmissao, string dataDemissao, bool statusAdmin, int codigo, 
            string nome, string rg, string cpf, string telefone, string endereco, string email, string usuario, string senha, 
            bool statusBD)
            : base(codigo, nome, rg, cpf, telefone, endereco, email, usuario, senha)
        {
            DataAdmissao = dataAdmissao;
            DataDemissao = dataDemissao;
            StatusAdmin = statusAdmin;
        }
    }
}
