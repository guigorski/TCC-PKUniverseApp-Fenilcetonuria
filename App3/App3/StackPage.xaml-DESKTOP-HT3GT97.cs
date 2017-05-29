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
    public partial class StackPage : ContentPage
    {
        public StackPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListarProdutos());
        }

        async void Atualizar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AtualizarDados());
        }

        async void MeusItens_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MeusItens());
        }

        async void MinhasDietas_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Dietas());
        }
    }
}
