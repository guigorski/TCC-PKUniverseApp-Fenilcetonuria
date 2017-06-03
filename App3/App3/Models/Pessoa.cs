using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace App3
{
    public class Pessoa
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string Nome { get; set; }

        public string Peso { get; set; }

        public DateTime Data { get; set; }

        
    }
   
}
