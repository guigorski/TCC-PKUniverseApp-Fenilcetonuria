using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3
{
    class Grupos : List<Produto>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }

        public Grupos(string title, String shortTitle)
        {
            Title = title;
            ShortTitle = shortTitle;
        }
    }
}
