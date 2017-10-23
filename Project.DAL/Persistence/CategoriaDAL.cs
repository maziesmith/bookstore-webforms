using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Connection;
using Project.Entities;
using System.Data.SqlClient;

namespace Project.DAL.Persistence
{
    public class CategoriaDAL : Conexao
    {
        public void Insert(string nome)
        {
            OpenConnection();

            string query = "Insert into Categoria(Nome) values(@Nome)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public Categoria FindById(int idCategoria)
        {
            OpenConnection();

            string query = "select * from Categoria where IdCategoria = @IdCategoria";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
            dr = cmd.ExecuteReader();

            Categoria c = null;
            if (dr.Read())
            {
                c = new Categoria();
                c.IdCategoria = (int)dr["IdCategoria"];
                c.Nome = (string)dr["Nome"];
            }
            CloseConnection();
            return c;
        }

        public List<Categoria> FindAll()
        {
            OpenConnection();

            string query = "select * from Categoria order by Nome";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Categoria> lista = new List<Categoria>();

            while (dr.Read())
            {
                Categoria c = new Categoria();
                c.IdCategoria = (int)dr["IdCategoria"];
                c.Nome = (string)dr["Nome"];

                lista.Add(c);
            }

            CloseConnection();
            return lista;
        }

        public void Update(Categoria c)
        {
            OpenConnection();

            string query = "update Categoria set Nome = @Nome where IdCategoria = @IdCategoria";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@IdCategoria", c.IdCategoria);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public void Delete(int idCategoria)
        {
            OpenConnection();

            string query = "delete from Categoria where IdCategoria = @IdCategoria";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

    }
}
