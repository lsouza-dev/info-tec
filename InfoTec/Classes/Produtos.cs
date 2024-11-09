using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTec.Classes
{
    public class Produtos
    {

        int id;
        string descricao;
        decimal valorProduto;

        public Produtos()
        {
        }

        public Produtos(int id, string descricao, decimal valorProduto)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.ValorProduto = valorProduto;
        }
            
        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public decimal ValorProduto { get => valorProduto; set => valorProduto = value; }
    }
}
