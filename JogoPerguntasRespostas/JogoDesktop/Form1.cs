using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDesktop
{
    public partial class frmInicial : Form
    {
        public frmInicial()
        {
            InitializeComponent();
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            txtNome.Text = "";
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {

            if(txtNome.Text == "")
            {
                txtNome.Text = "Digite seu nome";
            }

        }

        private void frmInicial_Load(object sender, EventArgs e)
        {
           
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "Digite seu nome")
            {
                MessageBox.Show("Você deve informar seu nome", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
            }else{

                //início do código para inserir o jogador na tabela
                //using System.Data.SqlClient;
                using (SqlConnection conexao = new SqlConnection("Server=AME0556344W10-1\\SQLEXPRESS;Database=db_PerguntasERespostas;Trusted_Connection=Yes"))
                {
                    using(SqlCommand comando = new SqlCommand("insert into tb_jogador(nome) OUTPUT INSERTED.ID values(@NOME)", conexao))
                    {
                        comando.Parameters.AddWithValue("NOME", txtNome.Text);
                        conexao.Open();

                        int id_jogador = (int)comando.ExecuteScalar();
                        if (id_jogador > 0) 
                        {
                          

                            MessageBox.Show("o id inserido foi: " + id_jogador);

                            MessageBox.Show("Olá " + txtNome.Text.ToUpper() + ". Você está pronto para continuar!!!", "PLAYYYY", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            //execuçao do som
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                            player.SoundLocation = "C:\\Users\\philipe.bmassieu\\Desktop\\cartoon008.wav";
                            player.Play();

                            //abertura do formulario de peergunta
                            Pergunta1 p1 = new Pergunta1(id_jogador);
                            p1.ShowDialog();
                            Pergunta2 p2 = new Pergunta2(id_jogador);
                            p2.ShowDialog();
                            Pergunta3 p3 = new Pergunta3(id_jogador);
                            p3.ShowDialog();
                            Pergunta4 p4 = new Pergunta4(id_jogador);
                            p4.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("DEU RUIMMMM!!!! Algo aconteceu durante o insert");
                        }
                    }
                }
                //fim do código para inserir o jogador na tabela
            }
        }
    }
}
