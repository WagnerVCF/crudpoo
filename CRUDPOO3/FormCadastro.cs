using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDPOO3
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Jogador jogador = new Jogador();
            jogador.Inserir(txtNome.Text, txtCidade.Text, txtemail.Text, txtCelular.Text);
            MessageBox.Show("Jogador inserido com sucesso!", "Inserção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List<Jogador> jogadores = jogador.listajogadores();
            dgvJogador.DataSource = jogadores;
            txtNome.Text = "";
            txtCidade.Text = string.Empty;
            txtemail.Text = "";
            txtCelular.Text = "";
        }

        private void FormCadastro_Load(object sender, EventArgs e)
        {
            Jogador jogador = new Jogador();
            List<Jogador> jogadores = jogador.listajogadores();
            dgvJogador.DataSource = jogadores;
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text.Trim());
            Jogador jogador = new Jogador();
            jogador.Localizar(id);
            txtNome.Text = jogador.nome;
            txtCidade.Text = jogador.cidade;
            txtemail.Text = jogador.email;
            txtCelular.Text = jogador.celular;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text.Trim());
            Jogador jogador = new Jogador();
            jogador.Atualizar(id, txtNome.Text, txtCidade.Text, txtemail.Text, txtCelular.Text);
            MessageBox.Show("Jogador atualizado com sucesso!", "Atualização", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List<Jogador> jogadores = jogador.listajogadores();
            dgvJogador.DataSource = jogadores;
            txtNome.Text = "";
            txtCidade.Text = "";
            txtemail.Text = "";
            txtCelular.Text = "";
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text.Trim());
            Jogador jogador = new Jogador();
            jogador.Excluir(id);
            MessageBox.Show("Jogador excluído com sucesso!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List<Jogador> jogadores = jogador.listajogadores();
            dgvJogador.DataSource = jogadores;
            txtNome.Text = "";
            txtCidade.Text = "";
            txtemail.Text = "";
            txtCelular.Text = "";
        }
    }
}
