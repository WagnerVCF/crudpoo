using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUDPOO
{
    class Aluno
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string curso { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\CRUDPOO\\CRUDPOO\\DbAluno.mdf;Integrated Security=True");

        public void Inserir(string nome, string curso)
        {
            string sql = "INSERT INTO Aluno(nome,curso) VALUES ('"+nome+"','"+curso+"')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Aluno> listaalunos()
        {
            List<Aluno> li = new List<Aluno>();
            string sql = "SELECT * FROM Aluno";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Aluno a = new Aluno();
                a.Id = (int)dr["Id"];
                a.nome = dr["nome"].ToString();
                a.curso = dr["curso"].ToString();
                li.Add(a);
            }
            return li;
        }

        public void Localiza(int id)
        {
            string sql = "SELECT * FROM Aluno WHERE Id = '"+id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                nome = rd["nome"].ToString();
                curso = rd["curso"].ToString();
            }
        }

        public void Atualizar(int id, string nome, string curso)
        {
            string sql = "UPDATE Aluno SET nome = '" + nome + "', curso = '" + curso + "' WHERE Id = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int id)
        {
            string sql = "DELETE FROM Aluno WHERE Id = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
