using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTec.Classes
{
    public class ProdutoVenda
    {
        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public decimal Qtd { get; set; }
        public  decimal ValorTotal { get; set; }

        public ProdutoVenda()
        {
        }

        public ProdutoVenda(int idVenda, int idProduto, decimal qtd, decimal valorTotal)
        {
            IdVenda = idVenda;
            IdProduto = idProduto;
            Qtd = qtd;
            ValorTotal = valorTotal;
        }
    }
}
