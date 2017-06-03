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
            await Navigation.PushAsync(new AtualizarDados());
        }

        async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListarProdutos());
        }

        async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MeusItens());
        }

        async void Button_Clicked_3(object sender, EventArgs e)
        {
           /// await Navigation.PushAsync(new Dietas());
        }
    }
}
