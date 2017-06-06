using App3.Models;
using SQLite;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeletarMeuItem : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<MeuItem> _produto;
        public DeletarMeuItem()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        protected override async void OnAppearing()
        {

            await _connection.CreateTableAsync<MeuItem>();


            var produtos = await _connection.Table<MeuItem>().ToListAsync();

            _produto = new ObservableCollection<MeuItem>(produtos);


            listView.ItemsSource = _produto;

            base.OnAppearing();
        }


        async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var produto = e.SelectedItem as MeuItem;

            var answer = await DisplayAlert("Deseja Deletar este Item?", "", "Deletar", "Cancelar");
            if (answer == true)
                _produto.Remove(produto);
            await _connection.DeleteAsync(produto);

            listView.SelectedItem = null;


        }

        async void Voltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}