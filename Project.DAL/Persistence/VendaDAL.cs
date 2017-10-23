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
    public class VendaDAL : Conexao
    {
        public int Insert(Venda v)
        {
            try
            {
                OpenConnection();

                tr = con.BeginTransaction();

                string queryVenda = "insert into Venda(DataVenda, Valor, Pagamento, IdCliente) values(@DataVenda, @Valor, @Pagamento, @IdCliente) select scope_identity()";

                cmd = new SqlCommand(queryVenda, con, tr);
                cmd.Parameters.AddWithValue("@DataVenda", v.DataVenda);
                cmd.Parameters.AddWithValue("@Valor", v.Valor);
                cmd.Parameters.AddWithValue("@Pagamento", v.Pagamento);                
                cmd.Parameters.AddWithValue("@IdCliente", v.Cliente.IdCliente);

                v.IdVenda = Convert.ToInt32(cmd.ExecuteScalar());

                string queryEntrega = "insert into EnderecoEntrega(IdEnderecoEntrega, Destinatario, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, Cep) values(@IdEnderecoEntrega, @Destinatario, @Logradouro, @Numero, @Complemento, @Bairro, @Cidade, @Estado, @Cep)";

                cmd = new SqlCommand(queryEntrega, con, tr);
                cmd.Parameters.AddWithValue("@IdEnderecoEntrega", v.IdVenda);
                cmd.Parameters.AddWithValue("@Destinatario", v.EnderecoEntrega.Destinatario);
                cmd.Parameters.AddWithValue("@Logradouro", v.EnderecoEntrega.Logradouro);
                cmd.Parameters.AddWithValue("@Numero", v.EnderecoEntrega.Numero);
                cmd.Parameters.AddWithValue("@Complemento", v.EnderecoEntrega.Complemento);
                cmd.Parameters.AddWithValue("@Bairro", v.EnderecoEntrega.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", v.EnderecoEntrega.Cidade);
                cmd.Parameters.AddWithValue("@Estado", v.EnderecoEntrega.Estado.ToString());
                cmd.Parameters.AddWithValue("@Cep", v.EnderecoEntrega.Cep);
                cmd.ExecuteNonQuery();

                foreach(ItemVenda i in v.Itens)
                {
                    string queryItem = "insert into ItemVenda(Quantidade, ValorTotal, IdVenda, IdLivro) values(@Quantidade, @ValorTotal, @IdVenda, @IdLivro)";
                    cmd = new SqlCommand(queryItem, con, tr);

                    cmd.Parameters.AddWithValue("@Quantidade", i.Quantidade);
                    cmd.Parameters.AddWithValue("@ValorTotal", i.ValorTotal);
                    cmd.Parameters.AddWithValue("@IdVenda", v.IdVenda);
                    cmd.Parameters.AddWithValue("@IdLivro", i.Livro.IdLivro);
                    cmd.ExecuteNonQuery();

                    //Alterando a quantidade de livros no estoque.
                    string queryUpdateLivro = "update Livro set Quantidade = Quantidade - @Quantidade where IdLivro = @IdLivro";
                    cmd = new SqlCommand(queryUpdateLivro, con, tr);

                    cmd.Parameters.AddWithValue("@Quantidade", i.Quantidade);
                    cmd.Parameters.AddWithValue("@IdLivro", i.Livro.IdLivro);
                    cmd.ExecuteNonQuery();
                }

                tr.Commit();
                return v.IdVenda;
                
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
       
        public List<Venda> SelectByCliente(int idCliente)
        {
            try
            {
                OpenConnection();
                string query = "select * from Venda where IdCliente = @IdCliente order by IdVenda desc";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                dr = cmd.ExecuteReader();

                List<Venda> lista = new List<Venda>();
                while (dr.Read())
                {
                    Venda v = new Venda();
                    v.IdVenda = (int)dr["IdVenda"];
                    v.DataVenda = (DateTime)dr["DataVenda"];
                    v.Valor = (decimal)dr["Valor"];

                    lista.Add(v);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
