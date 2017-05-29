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
    public partial class NovoMeuItem : ContentPage
    {
        public NovoMeuItem()
        {
            InitializeComponent();
        }

        private void enviar_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Novo Item foi adicionado!", "Seu novo item foi adicionado com sucesso!", "OK");
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
