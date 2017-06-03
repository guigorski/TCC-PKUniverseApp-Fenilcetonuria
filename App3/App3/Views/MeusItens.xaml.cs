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


        public MeusItens()
        {

            InitializeComponent();


            listView.ItemsSource = GetProduto();

        }

        public IEnumerable<Produto> GetProduto(string searchText = null)
        {


            var xprodutos = new List<Produto>
            {

                new Produto { Nome= "Sanduiche de Presunto e Queijo",Ingredientes= "Pao frances, Presunto, Queijo, Margarina "  ,Proteinas= 12, Quantidade= "150g",Calorias=400},

            };

            if (String.IsNullOrWhiteSpace(searchText))
                return xprodutos;

            return xprodutos.Where(c => c.Nome.StartsWith(searchText));
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
            var quantidade = produto.Quantidade;
            var cal = produto.Calorias;
            var answer = await DisplayAlert("Adicionar ao Acompanhamento diário", "Nome: " + nome + "\nQuantidade (Porção de todos os itens): " + quantidade + "\nProteina: " + proteina + "\nFenilanina: " + fenil + "\nCalorias: " + cal, "Adicionar", "Cancelar");
            if (answer == true)
                await Navigation.PushAsync(new Dietas(produto));


            listView.SelectedItem = null;

        }


    }
}
