using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Pessoa
    {
        //declarar propriedades
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Endereco {get; set;}
        public string Email{get;set;}
        public string Usuario { get; set; }
        public string Senha { get; set; }

        



        //construtores
        public Pessoa(int codigo, string nome, string rg, string cpf, string telefone, string endereco, 
            string email, string usuario, string senha)
        {
            Codigo = codigo;
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Telefone = telefone;
            Endereco = endereco;
            Email = email;
            Usuario = usuario;
            Senha = senha;
        }

        public Pessoa() {}


    }
}
