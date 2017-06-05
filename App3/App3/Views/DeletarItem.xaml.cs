using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeletarItem : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Produto> _produto;
        public DeletarItem()
        {


            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        protected override async void OnAppearing()
        {

            await _connection.CreateTableAsync<Produto>();


            var produtos = await _connection.Table<Produto>().ToListAsync();

            _produto = new ObservableCollection<Produto>(produtos);


            listView.ItemsSource = _produto;

            base.OnAppearing();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var produto = e.SelectedItem as Produto;
           
            var answer = await DisplayAlert("Deseja Deletar este Item?", "", "Deletar", "Cancelar");
            if (answer == true)
                _produto.Remove(produto);
                await _connection.DeleteAsync(produto);

            listView.SelectedItem = null;


        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }



    }
}