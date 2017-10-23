using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Connection;
using Project.Entities;
using System.Data.SqlClient;
using Project.Util;

namespace Project.DAL.Persistence
{
    public class ClienteDAL : Conexao
    {
        public void Insert(Cliente c)
        {
            try
            {
                OpenConnection();

                tr = con.BeginTransaction();

                string queryCliente = "insert into Cliente(Nome, Sobrenome, CPF, Email, Sexo, DataNascimento, Senha) values(@Nome, @Sobrenome, @CPF, @Email, @Sexo, @DataNascimento, @Senha) select scope_identity()";
                cmd = new SqlCommand(queryCliente, con, tr);
                cmd.Parameters.AddWithValue("@Nome", c.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", c.Sobrenome);
                cmd.Parameters.AddWithValue("@CPF", c.CPF);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@Sexo", c.Sexo);
                cmd.Parameters.AddWithValue("@DataNascimento", c.DataNascimento);
                cmd.Parameters.AddWithValue("@Senha", Criptografia.Encriptar(c.Senha));

                c.IdCliente = Convert.ToInt32(cmd.ExecuteScalar());

                string queryEndereco = "insert into Endereco(IdEndereco, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, Cep) values(@IdEndereco, @Logradouro, @Numero, @Complemento, @Bairro, @Cidade, @Estado, @Cep)";
                cmd = new SqlCommand(queryEndereco, con, tr);
                cmd.Parameters.AddWithValue("@IdEndereco", c.IdCliente);
                cmd.Parameters.AddWithValue("@Logradouro", c.Endereco.Logradouro);
                cmd.Parameters.AddWithValue("@Numero", c.Endereco.Numero);
                cmd.Parameters.AddWithValue("@Complemento", c.Endereco.Complemento);
                cmd.Parameters.AddWithValue("@Bairro", c.Endereco.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", c.Endereco.Cidade);
                cmd.Parameters.AddWithValue("@Estado", c.Endereco.Estado.ToString());
                cmd.Parameters.AddWithValue("@Cep", c.Endereco.Cep);
                cmd.ExecuteNonQuery();

                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();

                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<Cliente> FindAll()
        {
            OpenConnection();

            string query = "select * from Cliente";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Cliente> lista = null;
            if (dr.Read())
            {
                lista = new List<Cliente>();
            }

            while (dr.Read())
            {
                Cliente c = new Cliente();
                c.IdCliente = (int)dr["IdCliente"];
                c.Nome = (string)dr["Nome"];
                c.Sobrenome = (string)dr["Sobrenome"];
                c.Sexo = (string)dr["Sexo"];
                c.Email = (string)dr["Email"];
                c.DataNascimento = (DateTime)dr["DataNascimento"];

                lista.Add(c);
            }
            CloseConnection();
            return lista;
        }

        public Cliente FindById(int idCliente)
        {
            OpenConnection();

            string query = "select * from Cliente c inner join Endereco e on c.IdCliente = e.IdEndereco where IdCliente = @IdCliente";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdCliente", idCliente);
            dr = cmd.ExecuteReader();

            Cliente c = null;

            if (dr.Read())
            {
                c = new Cliente();
                c.Endereco = new Endereco();
                c.Endereco.Estado = new Estados();

                c.IdCliente = (int)dr["IdCliente"];
                c.Nome = (string)dr["Nome"];
                c.Sobrenome = (string)dr["Sobrenome"];
                c.CPF = (string)dr["CPF"];
                c.Sexo = (string)dr["Sexo"];
                c.Email = (string)dr["Email"];
                c.DataNascimento = (DateTime)dr["DataNascimento"];                
                c.Endereco.Logradouro = (string)dr["Logradouro"];
                c.Endereco.Complemento = (string)dr["Complemento"];
                c.Endereco.Numero = (int)dr["Numero"];
                c.Endereco.Bairro = (string)dr["Bairro"];
                c.Endereco.Cidade = (string)dr["Cidade"];
                c.Endereco.Estado = (Estados)Enum.Parse(typeof (Estados), (string)dr["Estado"]);
                c.Endereco.Cep = (string)dr["Cep"];
            }

            CloseConnection();
            return c;
        }

        public bool EmailExistente(string email)
        {
            try
            {
                OpenConnection();

                string query = "select count(*) from Cliente where Email = @Email";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);
                int qtd = Convert.ToInt32(cmd.ExecuteScalar());

                return qtd > 0;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }


        }

        public Cliente Autenticar(string email, string senha)
        {
            try
            {
                OpenConnection();

                string query = "select * from Cliente where Email = @Email and Senha = @Senha";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Senha", Criptografia.Encriptar(senha));
                dr = cmd.ExecuteReader();

                Cliente c = null;

                if (dr.Read())
                {
                    c = new Cliente();
                    c.IdCliente = (int)dr["IdCliente"];
                    c.Nome = (string)dr["Nome"];
                    c.Email = (string)dr["Email"];
                }
                return c;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            finally
            {
                CloseConnection();
            }
        }

        public void UpdateSemSenha(Cliente c)
        {
            try
            {
                OpenConnection();
                tr = con.BeginTransaction();
                string queryCliente = "update Cliente set Nome = @Nome, Sobrenome = @Sobrenome, Sexo = @Sexo, DataNascimento = @DataNascimento where IdCliente = @IdCliente";

                cmd = new SqlCommand(queryCliente, con, tr);
                cmd.Parameters.AddWithValue("@Nome", c.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", c.Sobrenome);
                cmd.Parameters.AddWithValue("@Sexo", c.Sexo);
                cmd.Parameters.AddWithValue("@DataNascimento", c.DataNascimento);
                cmd.Parameters.AddWithValue("@IdCliente", c.IdCliente);
                cmd.ExecuteNonQuery();

                string queryEndereco = "update Endereco set Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado, Cep = @Cep where IdEndereco = @IdEndereco";
                cmd = new SqlCommand(queryEndereco, con, tr);
                cmd.Parameters.AddWithValue("@Logradouro", c.Endereco.Logradouro);
                cmd.Parameters.AddWithValue("@Numero", c.Endereco.Numero);
                cmd.Parameters.AddWithValue("@Complemento", c.Endereco.Complemento);
                cmd.Parameters.AddWithValue("@Bairro", c.Endereco.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", c.Endereco.Cidade);
                cmd.Parameters.AddWithValue("@Estado", c.Endereco.Estado);
                cmd.Parameters.AddWithValue("@Cep", c.Endereco.Cep);
                cmd.Parameters.AddWithValue("@IdEndereco", c.Endereco.IdEndereco);
                cmd.ExecuteNonQuery();

                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public void UpdateComSenha(Cliente c)
        {
            try
            {
                OpenConnection();
                tr = con.BeginTransaction();
                string queryCliente = "update Cliente set Nome = @Nome, Sobrenome = @Sobrenome, Sexo = @Sexo, DataNascimento = @DataNascimento, Senha = @Senha where IdCliente = @IdCliente";

                cmd = new SqlCommand(queryCliente, con, tr);
                cmd.Parameters.AddWithValue("@Nome", c.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", c.Sobrenome);
                cmd.Parameters.AddWithValue("@Sexo", c.Sexo);
                cmd.Parameters.AddWithValue("@DataNascimento", c.DataNascimento);
                cmd.Parameters.AddWithValue("@IdCliente", c.IdCliente);
                cmd.Parameters.AddWithValue("@Senha", Criptografia.Encriptar(c.Senha));
                cmd.ExecuteNonQuery();

                string queryEndereco = "update Endereco set Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado, Cep = @Cep where IdEndereco = @IdEndereco";
                cmd = new SqlCommand(queryEndereco, con, tr);
                cmd.Parameters.AddWithValue("@Logradouro", c.Endereco.Logradouro);
                cmd.Parameters.AddWithValue("@Numero", c.Endereco.Numero);
                cmd.Parameters.AddWithValue("@Complemento", c.Endereco.Complemento);
                cmd.Parameters.AddWithValue("@Bairro", c.Endereco.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", c.Endereco.Cidade);
                cmd.Parameters.AddWithValue("@Estado", c.Endereco.Estado);
                cmd.Parameters.AddWithValue("@Cep", c.Endereco.Cep);
                cmd.Parameters.AddWithValue("@IdEndereco", c.Endereco.IdEndereco);
                cmd.ExecuteNonQuery();

                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }  

}
