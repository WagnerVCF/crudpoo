using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDPOO
{
    public partial class FormAluno : Form
    {
        public FormAluno()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            aluno.Inserir(txtNome.Text, txtCurso.Text);
            MessageBox.Show("Aluno inserido com sucesso!", "Inserção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List<Aluno> alunos = aluno.listaalunos();
            dgvAluno.DataSource = alunos;
            txtNome.Text = string.Empty;
            txtCurso.Text = string.Empty;
        }

        private void FormAluno_Load(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            List<Aluno> alunos = aluno.listaalunos();
            dgvAluno.DataSource = alunos;
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text.Trim());
            Aluno aluno = new Aluno();
            aluno.Localiza(id);
            txtNome.Text = aluno.nome;
            txtCurso.Text = aluno.curso;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text.Trim());
            Aluno aluno = new Aluno();
            aluno.Atualizar(id, txtNome.Text, txtCurso.Text);
            MessageBox.Show("Aluno atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List<Aluno> alunos = aluno.listaalunos();
            dgvAluno.DataSource = alunos;
            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCurso.Text = string.Empty;
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text.Trim());
            Aluno aluno = new Aluno();
            aluno.Excluir(id);
            MessageBox.Show("Aluno excluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List<Aluno> alunos = aluno.listaalunos();
            dgvAluno.DataSource = alunos;
            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCurso.Text = string.Empty;
        }
    }
}
