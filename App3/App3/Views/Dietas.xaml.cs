using App3.Models;
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
    public partial class Dietas : ContentPage
    {
        private List<Produto> _produto = new List<Produto>();

        public Dietas(Produto produto = null, MeuItem meuitem = null)
        {

            InitializeComponent();

            var x = produto;
            addProduto(x);

            listView.ItemsSource = GetProduto();
        }
        
        public void addProduto(Produto produto)
        {
             _produto.Add(produto);

        }

        public IEnumerable<Produto> GetProduto()
        {
            return _produto;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await ProgressBar.ProgressTo(0.3, 900, Easing.Linear);
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Adicionar novo Item", "Adicione aqui seu novo item personalizado", "OK");
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListarProdutos());

        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var produto = e.SelectedItem as Produto;
            var nome = produto.Nome;
            var proteina = produto.Proteinas;
            var fenil = ((produto.Proteinas * 0.05));
            var cal = produto.Calorias;
            DisplayAlert("Adicionar ao Acompanhamento diário", "Nome: " + nome + "\nProteina: " + proteina + "\nFenilanina: " + fenil + "\nCalorias: " + cal, "OK");


            listView.SelectedItem = null;
        }

        async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MeusItens());

        }
    }
}
