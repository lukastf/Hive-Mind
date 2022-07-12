using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using ProjetoBackEnd.Entity;

namespace ProjetoBackEnd.Data
{
    public class BoletoData : Conexao
    {
        string stringConexao = "";
        public BoletoData(string strConexao)
            : base(strConexao) 
        {
            this.stringConexao = strConexao;
        }

        public bool Inserir(Boleto boleto)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"exec addBoleto @id_unidade, @valor, @dataGeracao, @dataValidade, @dataPagamento, @bancoReferente";

                Cmd.Parameters.AddWithValue("@id_unidade", boleto.Unidade.CodigoUnidade);
                Cmd.Parameters.AddWithValue("@valor", boleto.Valor);
                Cmd.Parameters.AddWithValue("@dataGeracao", boleto.DataGeracao);
                Cmd.Parameters.AddWithValue("@dataValidade", boleto.DataValidade);
                Cmd.Parameters.AddWithValue("@dataPagamento", boleto.DataPagamento);
                Cmd.Parameters.AddWithValue("@bancoReferente", boleto.BancoReferente);


                Cmd.ExecuteNonQuery();

                ok = true;
            }
            catch { }
            return ok;
        }

        public bool Editar(Boleto boleto)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"exec editBoleto @id_unidade,@valor, @dataGeracao, @dataValidade, @dataPagamento, @bancoReferente, @id_boleto";

                Cmd.Parameters.AddWithValue("@id_unidade", boleto.Unidade.CodigoUnidade);
                Cmd.Parameters.AddWithValue("@valor", boleto.Valor);
                Cmd.Parameters.AddWithValue("@dataGeracao", boleto.DataGeracao);
                Cmd.Parameters.AddWithValue("@dataValidade", boleto.DataValidade);
                Cmd.Parameters.AddWithValue("@dataPagamento", boleto.DataPagamento);
                Cmd.Parameters.AddWithValue("@bancoReferente", boleto.BancoReferente);
                Cmd.Parameters.AddWithValue("@id_boleto", boleto.CodigoBoleto);
               
                Cmd.ExecuteNonQuery();

                ok = true;
            }
            catch { }

            return ok;
        }

        public bool Excluir(Boleto boleto)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" delete from boletos where id_boleto = @id_boleto";

                Cmd.Parameters.AddWithValue("@id_boleto", boleto.CodigoBoleto);

                Cmd.ExecuteNonQuery();
                ok = true;
            }
            catch { }

            return ok;
        }

        public Boleto ObterBoleto(int codigo)
        {
            Boleto boleto = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from boletos where id_boleto = @id_boleto ";

                Cmd.Parameters.AddWithValue("@id_boleto", codigo);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    boleto = CadastrarBoleto(Dr);
                }
            }
            catch { }

            return boleto;
        }

        private Boleto CadastrarBoleto(SqlDataReader Dr)
        {
            Boleto boleto = new Boleto();
            Unidade unidade = new Unidade();
            UnidadeData uData = new UnidadeData(stringConexao);

            boleto.CodigoBoleto = Dr.GetInt32(0);
            boleto.Unidade = uData.ObterUnidadeID(Dr.GetInt32(1));
            boleto.Localizacao = boleto.Unidade.Localizacao;
            boleto.Valor = Dr.GetDecimal(2);
            boleto.DataGeracao = Dr.GetString(3);
            boleto.DataValidade = Dr.GetString(4);
            boleto.DataPagamento = Dr.GetString(5);
            boleto.BancoReferente = Dr.GetString(6);

            return boleto;
        }

        public List<Boleto> Listar()
        {
            List<Boleto> produtos = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from boletos ";

                Dr = Cmd.ExecuteReader();
                produtos = new List<Boleto>();
                while (Dr.Read())
                {
                    produtos.Add(CadastrarBoleto(Dr));
                }
            }
            catch { }

            return produtos;
        }

        public List<Boleto> Pesquisar(int criterio, string pesquisa)
        {
            List<Boleto> boletos = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                string sql = "select * from boletos where ";
                if (criterio == 1)
                {
                    sql += " nome like '%" + pesquisa + "%'";
                }
                else if (criterio == 2)
                {
                    sql += " Codigo id = " + pesquisa;
                }

                Cmd.CommandText = sql;
                Dr = Cmd.ExecuteReader();
                boletos = new List<Boleto>();

                while (Dr.Read())
                {
                    boletos.Add(CadastrarBoleto(Dr));
                }
            }
            catch { }
            return boletos;
        }
    }
}