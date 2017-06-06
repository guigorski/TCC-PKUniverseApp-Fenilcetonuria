using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using App3.Models;

namespace App3
{
    public class Produto : IProduto
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Nome { get; set; }
        public string Quantidade { get; set; }
        public string Marca { get; set; }
        public string Ingredientes { get; set; }
        public double Proteinas { get; set; }
        public double Calorias { get; set; }

      

        public double getFenilalanina()
        {
            double fenilalanina;
            fenilalanina = Proteinas * 0.05;

            return fenilalanina;
        }
    }

   
}
