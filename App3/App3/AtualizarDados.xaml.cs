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
    public partial class AtualizarDados : ContentPage
    {
        public AtualizarDados()
        {
            InitializeComponent();
            
        }
        Pessoa pessoa = new Pessoa();
        async void Voltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void enviar_Clicked(object sender, EventArgs e)
        {
    
        }
    }
}
