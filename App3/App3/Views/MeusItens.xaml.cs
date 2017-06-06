using App3.Models;
using App3.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private SQLiteAsyncConnection _connection;
        private ObservableCollection<MeuItem> _produto;
        public MeusItens()
        {

            InitializeComponent();


           

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();


        }

        protected override async void OnAppearing()
        {

            await _connection.CreateTableAsync<MeuItem>();


          


            listView.ItemsSource = GetProduto();

            base.OnAppearing();
        }



        public IEnumerable<MeuItem> GetProduto(string searchText = null)
        {


            var xprodutos = new List<MeuItem>
            {

                new MeuItem { Nome= "Sanduiche de Presunto e Queijo",Ingredientes= "Pao frances, Presunto, Queijo, Margarina "  ,Proteinas= 12, Quantidade= "150g",Calorias=400},

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
            var produto = e.SelectedItem as MeuItem;
            var nome = produto.Nome;
            var fenil = produto.getFenilalanina(produto.Proteinas);
            var proteina = (produto.Proteinas);
            var cal = produto.Calorias;
            var quantidade = produto.Quantidade;
            var answer = await DisplayAlert("Adicionar ao Acompanhamento diário", "Nome: " + nome + "\nQuantidade (Porção): " + quantidade + "\nProteina: " + proteina + "\nFenilanina: " + fenil +
                "\nCalorias: " + cal, "Adicionar", "Cancelar");
            if (answer == true)
                await Navigation.PushAsync(new Dietas(null, produto));



            listView.SelectedItem = null;

        }

        async void AddNovoItem_Clicked(object sender, EventArgs e)
        {
          await  Navigation.PushAsync(new NovoMeuItem());
        }

        async void DeletarNovoItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeletarMeuItem());
        }
    }
}
