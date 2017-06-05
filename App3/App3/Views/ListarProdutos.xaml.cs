using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarProdutos : ContentPage

    {

        public ListarProdutos()
        {
            InitializeComponent();


            listView.ItemsSource = GetProduto();


        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            listView.ItemsSource = GetProduto(e.NewTextValue);
        }

        public IEnumerable<Produto> GetProduto(string searchText = null)
        {


            var xprodutos = new List<Produto>
            {
                new Produto { Nome= "Bolacha Trakinas Chocolate e Morango",Proteinas= 1.8, Quantidade= "162g",Calorias=146, Marca="Kraft Foods"},
                new Produto { Nome= "Chocolate Diamante Negro", Proteinas= 1.3, Quantidade= "100g",Calorias = 127, Marca="Lacta"},
                new Produto { Nome= "Farinha Lactea", Proteinas= 0.95, Quantidade= "210g", Calorias = 119, Marca="Nestlé"},

            };

            if (String.IsNullOrWhiteSpace(searchText))
                return xprodutos;

            return xprodutos.Where(c => c.Nome.StartsWith(searchText));
        }

        



        async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var produto = e.SelectedItem as Produto;
            var nome = produto.Nome;
            var fenil = produto.getFenilalanina(produto.Proteinas);
            var proteina = (produto.Proteinas);
            var cal = produto.Calorias;
            var quantidade = produto.Quantidade;
            var answer = await DisplayAlert("Adicionar ao Acompanhamento diário", "Nome: " + nome + "\nQuantidade (Porção): " + quantidade + "\nProteina: " + proteina + "\nFenilanina: " + fenil +
                "\nCalorias: " + cal, "Adicionar", "Cancelar");
            if (answer == true)
                 await Navigation.PushAsync(new Dietas(produto));


            listView.SelectedItem = null;


        }



        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }



        async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NovoItem());
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NovoItem());
        }


    }
}
