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
    public partial class MeusItens : ContentPage
    {
        private List<Grupos> _produto;
        
        public MeusItens()
        {

            InitializeComponent();

            _produto = new List<Grupos>
            {
                new Grupos ("S", "S")
                {
                                    new Produto { Nome= "Sanduiche de Presunto e Queijo",Ingredientes= "Pao frances, Presunto, Queijo, Margarina ", Proteinas= 12, Quantidade= "150g",Calorias=400},
                }
                };

            listView.ItemsSource = _produto;
        
    }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new NovoMeuItem());
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PopAsync();
        }

        async void btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NovoMeuItem());
        }

        async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var produto = e.SelectedItem as Produto;
            var nome = produto.Nome;
            var proteina = produto.Proteinas;
            var fenil = ((produto.Proteinas * 0.05));
            var cal = produto.Calorias;
            var answer = await DisplayAlert("Adicionar ao Acompanhamento diário", "Nome: " + nome + "\nProteina: " + proteina + "\nFenilanina: " + fenil + "\nCalorias: " + cal, "Adicionar", "Cancelar");
            if (answer == true)
                await Navigation.PushAsync(new Dietas(produto));


            listView.SelectedItem = null;

        }


    }
}
