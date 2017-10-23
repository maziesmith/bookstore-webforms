using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Entities;
using Project.DAL.Connection;
using System.Data.SqlClient;
using Project.Util;

namespace Project.DAL.Persistence
{
    public class AdministradorDAL : Conexao
    {
        public void Insert(Administrador a)
        {
            OpenConnection();

            string query = "insert into Administrador(Nome, Sobrenome, Email, Senha) values(@Nome, @Sobrenome, @Email, @Senha)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", a.Nome);
            cmd.Parameters.AddWithValue("@Sobrenome", a.Sobrenome);
            cmd.Parameters.AddWithValue("@Email", a.Email);
            cmd.Parameters.AddWithValue("@Senha", Criptografia.Encriptar(a.Senha));
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public bool EmailExistente(string email)
        {
            try
            {
                OpenConnection();

                string query = "select count(*) from Administrador where Email = @Email";

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

        public Administrador Autenticar(string email, string senha)
        {
            try
            {
                OpenConnection();

                string query = "select * from Administrador where Email = @Email and Senha = @Senha";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Senha", Criptografia.Encriptar(senha));
                dr = cmd.ExecuteReader();

                Administrador a = null;

                if (dr.Read())
                {
                    a = new Administrador();
                    a.IdAdministrador = (int)dr["IdAdministrador"];
                    a.Nome = (string)dr["Nome"];
                    a.Sobrenome = (string)dr["Sobrenome"];
                    a.Email = (string)dr["Email"];
                }
                return a;
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
    }
}
