using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Livro
    {
        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string AnoEdicao { get; set; }
        public decimal Preco { get; set; }
        public string Foto { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }

        public Categoria Categoria { get; set; }

        public Livro()
        {

        }
        public Livro(int idLivro, string titulo, string autor, string editora, string anoEdicao, decimal preco, string foto, int quant, string desc)
        {
            IdLivro = idLivro;
            Titulo = titulo;
            Autor = autor;          
            Editora = editora;
            AnoEdicao = anoEdicao;
            Preco = preco;
            Foto = foto;
            Quantidade = quant;
            Descricao = desc;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}", IdLivro, Titulo, Autor, Editora, AnoEdicao, Preco);
        }
    }
}
