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
    public class LivroDAL : Conexao
    {
        public void Insert(Livro l)
        {
            OpenConnection();

            string query = "insert into Livro(Titulo, Autor, Editora, AnoEdicao, Preco, IdCategoria, Foto, Quantidade, Descricao) values(@Titulo, @Autor, @Editora, @AnoEdicao, @Preco, @IdCategoria, @Foto, @Quantidade, @Descricao)";

            cmd = new SqlCommand(query, con);            
            cmd.Parameters.AddWithValue("@Titulo", l.Titulo);
            cmd.Parameters.AddWithValue("@Autor",l.Autor);
            cmd.Parameters.AddWithValue("@Editora", l.Editora);
            cmd.Parameters.AddWithValue("@AnoEdicao", l.AnoEdicao);
            cmd.Parameters.AddWithValue("@Preco",l.Preco);
            cmd.Parameters.AddWithValue("@IdCategoria",l.Categoria.IdCategoria);
            cmd.Parameters.AddWithValue("@Foto", l.Foto);
            cmd.Parameters.AddWithValue("@Quantidade", l.Quantidade);
            cmd.Parameters.AddWithValue("@Descricao", l.Descricao);

            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public List<Livro> FindAll()
        {
            OpenConnection();

            string query = "select * from Livro l inner join Categoria c on l.IdCategoria = c.IdCategoria order by l.Titulo";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Livro> lista = new List<Livro>();

            while (dr.Read())
            {
                Livro l = new Livro();
                l.Categoria = new Categoria();

                l.IdLivro = (int)dr["IdLivro"];
                l.Titulo = (string)dr["Titulo"];
                l.Autor = (string)dr["Autor"];
                l.Editora = (string)dr["Editora"];
                l.AnoEdicao = (string)dr["AnoEdicao"];
                l.Preco = (decimal)dr["Preco"];
                l.Categoria.IdCategoria = (int)dr["IdCategoria"];
                l.Categoria.Nome = (string)dr["Nome"];
                l.Foto = (string)dr["Foto"];
                l.Quantidade = (int)dr["Quantidade"];
                l.Descricao = (string)dr["Descricao"];

                lista.Add(l);
            }
            CloseConnection();
            return lista;
        }

        public void Delete(int idLivro)
        {
            OpenConnection();

            string query = "delete from Livro where IdLivro = @IdLivro";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdLivro", idLivro);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public List<Livro> FindByTitulo(string titulo)
        {
            OpenConnection();

            string query = "select * from Livro l inner join Categoria c on l.IdCategoria = c.IdCategoria where l.Titulo like @Titulo order by l.Titulo";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Titulo", string.Format("%{0}%", titulo));
            dr = cmd.ExecuteReader();

            List<Livro> lista = new List<Livro>();

            while (dr.Read())
            {
                Livro l = new Livro();
                l.Categoria = new Categoria();

                l.IdLivro = (int)dr["IdLivro"];
                l.Titulo = (string)dr["Titulo"];
                l.Autor = (string)dr["Autor"];
                l.Editora = (string)dr["Editora"];
                l.AnoEdicao = (string)dr["AnoEdicao"];
                l.Preco = (decimal)dr["Preco"];
                l.Categoria.IdCategoria = (int)dr["IdCategoria"];
                l.Categoria.Nome = (string)dr["Nome"];
                l.Foto = (string)dr["Foto"];
                l.Quantidade = (int)dr["Quantidade"];
                l.Descricao = (string)dr["Descricao"];

                lista.Add(l);
            }
            CloseConnection();
            return lista;
        }

        public List<Livro> FindByAutor(string autor)
        {
            OpenConnection();

            string query = "select * from Livro l inner join Categoria c on l.IdCategoria = c.IdCategoria where l.Autor like @Autor order by l.Titulo";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Autor", string.Format("%{0}%", autor));
            dr = cmd.ExecuteReader();

            List<Livro> lista = new List<Livro>();

            while (dr.Read())
            {
                Livro l = new Livro();
                l.Categoria = new Categoria();

                l.IdLivro = (int)dr["IdLivro"];
                l.Titulo = (string)dr["Titulo"];
                l.Autor = (string)dr["Autor"];
                l.Editora = (string)dr["Editora"];
                l.AnoEdicao = (string)dr["AnoEdicao"];
                l.Preco = (decimal)dr["Preco"];
                l.Categoria.IdCategoria = (int)dr["IdCategoria"];
                l.Categoria.Nome = (string)dr["Nome"];
                l.Foto = (string)dr["Foto"];
                l.Quantidade = (int)dr["Quantidade"];
                l.Descricao = (string)dr["Descricao"];

                lista.Add(l);
            }
            CloseConnection();
            return lista;
        }
        public List<Livro> FindByCategoria(string categoria)
        {
            OpenConnection();

            string query = "select * from Livro l inner join Categoria c on l.IdCategoria = c.IdCategoria where c.Nome like @categoria order by l.Titulo";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Categoria", string.Format("%{0}%", categoria));
            dr = cmd.ExecuteReader();

            List<Livro> lista = new List<Livro>();

            while (dr.Read())
            {
                Livro l = new Livro();
                l.Categoria = new Categoria();

                l.IdLivro = (int)dr["IdLivro"];
                l.Titulo = (string)dr["Titulo"];
                l.Autor = (string)dr["Autor"];
                l.Editora = (string)dr["Editora"];
                l.AnoEdicao = (string)dr["AnoEdicao"];
                l.Preco = (decimal)dr["Preco"];
                l.Categoria.IdCategoria = (int)dr["IdCategoria"];
                l.Categoria.Nome = (string)dr["Nome"];
                l.Foto = (string)dr["Foto"];
                l.Quantidade = (int)dr["Quantidade"];
                l.Descricao = (string)dr["Descricao"];

                lista.Add(l);
            }
            CloseConnection();
            return lista;
        }

        public Livro FindById(int idLivro)
        {
            OpenConnection();

            string query = "select * from Livro l inner join Categoria c on l.IdCategoria = c.IdCategoria where l.IdLivro = @IdLivro";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdLivro", idLivro);
            dr = cmd.ExecuteReader();

            Livro l = null;

            if (dr.Read())
            {
                l = new Livro();
                l.Categoria = new Categoria();

                l.IdLivro = (int)dr["IdLivro"];
                l.Titulo = (string)dr["Titulo"];
                l.Autor = (string)dr["Autor"];
                l.Editora = (string)dr["Editora"];
                l.AnoEdicao = (string)dr["AnoEdicao"];
                l.Preco = (decimal)dr["Preco"];
                l.Categoria.IdCategoria = (int)dr["IdCategoria"];
                l.Categoria.Nome = (string)dr["Nome"];
                l.Foto = (string)dr["Foto"];
                l.Quantidade = (int)dr["Quantidade"];
                l.Descricao = (string)dr["Descricao"];

            }
            CloseConnection();
            return l;
            
        }

        public void Update(Livro l)
        {
            OpenConnection();

            string query = "update Livro set Titulo = @Titulo, Autor = @Autor, Editora = @Editora, AnoEdicao = @AnoEdicao, Preco = @Preco, IdCategoria = @IdCategoria, Foto = @Foto, Quantidade = @Quantidade, Descricao = @Descricao where IdLivro = @IdLivro";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdLivro", l.IdLivro);
            cmd.Parameters.AddWithValue("@Titulo", l.Titulo);
            cmd.Parameters.AddWithValue("@Autor", l.Autor);
            cmd.Parameters.AddWithValue("@Editora", l.Editora);
            cmd.Parameters.AddWithValue("@AnoEdicao", l.AnoEdicao);
            cmd.Parameters.AddWithValue("@Preco", l.Preco);
            cmd.Parameters.AddWithValue("@IdCategoria", l.Categoria.IdCategoria);
            cmd.Parameters.AddWithValue("@Foto", l.Foto);
            cmd.Parameters.AddWithValue("@Quantidade", l.Quantidade);
            cmd.Parameters.AddWithValue("@Descricao", l.Descricao);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public List<Livro> FindByAnything(string chave)
        {
            OpenConnection();

            string query = "select * from Livro l inner join Categoria c on l.IdCategoria = c.IdCategoria where c.Nome like @Chave or l.Titulo like @Chave or l.Autor like @Chave or l.Editora like @Chave or l.AnoEdicao like @Chave order by l.Titulo";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Chave", string.Format("%{0}%", chave));
            dr = cmd.ExecuteReader();

            List<Livro> lista = new List<Livro>();

            while (dr.Read())
            {
                Livro l = new Livro();
                l.Categoria = new Categoria();

                l.IdLivro = (int)dr["IdLivro"];
                l.Titulo = (string)dr["Titulo"];
                l.Autor = (string)dr["Autor"];
                l.Editora = (string)dr["Editora"];
                l.AnoEdicao = (string)dr["AnoEdicao"];
                l.Preco = (decimal)dr["Preco"];
                l.Categoria.IdCategoria = (int)dr["IdCategoria"];
                l.Categoria.Nome = (string)dr["Nome"];
                l.Foto = (string)dr["Foto"];
                l.Quantidade = (int)dr["Quantidade"];
                l.Descricao = (string)dr["Descricao"];

                lista.Add(l);
            }
            CloseConnection();
            return lista;
        }

        
    }
}
