using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUDPOO3
{
    class Jogador
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string cidade { get; set; }
        public string email { get; set; }
        public string celular { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\CRUDPOO3\\CRUDPOO3\\DbJogador.mdf;Integrated Security=True");

        public void Inserir(string nome, string cidade, string email, string celular)
        {
            string sql = "INSERT INTO Jogador(nome,cidade,email,celular) VALUES('"+nome+"','"+cidade+"','"+email+"','"+celular+"')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Jogador> listajogadores()
        {
            List<Jogador> li = new List<Jogador>();
            string sql = "SELECT * FROM Jogador";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Jogador j = new Jogador();
                j.Id = (int)dr["Id"];
                j.nome = dr["nome"].ToString();
                j.cidade = dr["cidade"].ToString();
                j.email = dr["email"].ToString();
                j.celular = dr["celular"].ToString();
                li.Add(j);
            }
            dr.Close();
            con.Close();
            return li;
        }

        public void Localizar(int id)
        {
            string sql = "SELECT * FROM Jogador WHERE Id = '"+id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                cidade = dr["cidade"].ToString();
                email = dr["email"].ToString();
                celular = dr["celular"].ToString();
            }
            dr.Close();
            con.Close();
        }

        public void Atualizar(int id, string nome, string cidade, string email, string celular)
        {
            string sql = "UPDATE Jogador SET nome = '"+nome+"', cidade = '"+cidade+"', email = '"+email+"', celular = '"+celular+"' WHERE Id = '"+id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int id)
        {
            string sql = "DELETE FROM Jogador WHERE Id = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
