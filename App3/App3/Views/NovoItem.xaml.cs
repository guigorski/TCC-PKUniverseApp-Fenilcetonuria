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
    public partial class NovoItem : ContentPage
    {
        public NovoItem()
        {
            InitializeComponent();
        }

        private void enviar_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Adicioado", "Produto adicionado com sucesso!", "OK");
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PopAsync();
        }
    }
}
