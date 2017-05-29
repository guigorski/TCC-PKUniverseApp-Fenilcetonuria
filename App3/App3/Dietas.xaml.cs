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
        private List<Produto> _produto;
        public Dietas(Produto produto)
        {

            InitializeComponent();

            _produto = new List<Produto>
            {
                 new Produto { Nome = produto.Nome, Quantidade = produto.Quantidade, Calorias = produto.Calorias, Proteinas = produto.Proteinas }
            };

            listView.ItemsSource = _produto;
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Adicionar novo Item", "Adicione aqui seu novo item personalizado", "OK");
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PopAsync();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Adicionar novo Item", "Adicione aqui seu novo item personalizado", "OK");

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
    }
}
