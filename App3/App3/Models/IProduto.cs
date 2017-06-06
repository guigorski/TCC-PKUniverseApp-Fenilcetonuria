using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3.Models
{
   public interface IProduto
    {

        int id { get; set; }
        string Nome { get; set; }
        string Quantidade { get; set; }
        string Marca { get; set; }
        string Ingredientes { get; set; }
        double Proteinas { get; set; }
         double Calorias { get; set; }

        double getFenilalanina();

    }
}
