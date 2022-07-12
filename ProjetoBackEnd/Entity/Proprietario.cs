using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Proprietario : Pessoa
    {
        public string Informacao { get; set; }

        public Proprietario() { }
        public Proprietario(string informacao, 
            int codigo, string nome,string rg,string cpf, string telefone, string endereco, string email, string usuario, string senha, bool statusBD)
            : base(codigo, nome, rg, cpf, telefone, endereco, email, usuario, senha)
        {
            Informacao = informacao;
        }
    }
}
