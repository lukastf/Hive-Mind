using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Unidade
    {
        public int CodigoUnidade { get; set; }
        public Pessoa Morador { get; set; }
        public Pessoa Proprietario { get; set; }
        public string Localizacao { get; set; }

        public string NomeMorador { get; set; }
        public string NomeProprietario { get; set; }

        public Unidade() { }
        public Unidade(Pessoa morador, Pessoa proprietario,string localizacao)
        {
            Morador = morador;
            Proprietario = proprietario;
            Localizacao = localizacao;
        }
    }
}
