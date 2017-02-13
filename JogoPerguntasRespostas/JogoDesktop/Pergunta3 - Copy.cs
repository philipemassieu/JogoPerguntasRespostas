using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JogoDesktop
{
    public partial class Pergunta3 : Form
    {
        public int id_jogador_banco;

        public Pergunta3(int id_jogador)
        {
            InitializeComponent();
            id_jogador_banco = id_jogador;
        }

        private void btnProxima_Click(object sender, EventArgs e)
        {
            if (rdbResposta4.Checked == true)
            {
                MessageBox.Show("acertou");

                //cadastrar no banco de dados a pergunta e a resposta 

                string path = "Server=AME0510018W10-1\\SQLEXPRESS;Database=db_PerguntasERespostas;Trusted_Connection=Yes";
                SqlConnection conexao = new SqlConnection(path);

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;

                string insert = "insert into tb_perguntas(pergunta, resposta_correta, id_Jogador) values (@PERGUNTA, @RESPOSTA_CORRETA, @ID_JOGADOR)";

                comando.CommandText = insert;

                conexao.Open();


                comando.Parameters.AddWithValue("@PERGUNTA", lblPergunta.Text);

                comando.Parameters.AddWithValue("@RESPOSTA_CORRETA", rdbResposta4.Text);

                comando.Parameters.AddWithValue("@ID_JOGADOR", id_jogador_banco);



                comando.ExecuteNonQuery();

                conexao.Close();

                this.Close();
            }
            else
            {
                MessageBox.Show("Você errou");
            }
        }
    }
}
