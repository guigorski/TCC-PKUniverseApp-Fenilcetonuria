using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3.Models
{
    public class MeuItem
    {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string Nome { get; set; }
        public string Quantidade { get; set; }
        public string Ingredientes { get; set; }
        public double Proteinas { get; set; }
        public double Calorias { get; set; }

        public double getFenilalanina(double proteinas)
        {
            double fenilalanina;
            fenilalanina = Proteinas * 0.05;

            return fenilalanina;
        }

    }
}
