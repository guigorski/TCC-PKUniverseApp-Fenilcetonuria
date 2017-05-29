using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesProdutos : ContentPage
    {
        public DetalhesProdutos(Produto produto)
        {

            if (produto == null)
                throw new ArgumentNullException();

            BindingContext = produto;
            InitializeComponent();
        }
    }
}