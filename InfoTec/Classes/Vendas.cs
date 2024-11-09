using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTec.Classes
{
    public class Vendas
    {
       
        public int IdVenda {get;set;}
        public string Cliente{ get; set; }
       
        public decimal ValorDesconto { get; set; }
        public decimal Valorfinal {  get; set; }

        public Vendas()
        {
        }

        public Vendas(int idVenda, string cliente, decimal valorDesconto, decimal valorfinal)
        {
            IdVenda = idVenda;
            
            Cliente = cliente;
           
            ValorDesconto = valorDesconto;
            Valorfinal = valorfinal;
        }
    }
}
