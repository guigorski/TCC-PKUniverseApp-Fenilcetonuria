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
    public partial class AtualizarDados : ContentPage
    {
        private ObservableCollection<Pessoa> _pessoa;
        private SQLiteAsyncConnection _connection;

        public AtualizarDados()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

           
           
        }
        protected override async void OnAppearing()
        {
           await _connection.CreateTableAsync<Pessoa>();

           
            var pessoas = await _connection.Table<Pessoa>().ToListAsync();
            _pessoa = new ObservableCollection<Pessoa>(pessoas);
            listView.ItemsSource = _pessoa;

            
            var pes = _pessoa[0];
            xNome.Text = pes.Nome;
            xPeso.Text = pes.Peso;
            xData.Text = pes.Idade;


            base.OnAppearing();
        }

        async void Voltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void enviar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Dados Atulizados com Sucesso!", "Os dados foram atualizados e já estão disponiveis para os calculos", "OK");
            var pes = _pessoa[0];
            pes.Nome = xNome.Text;
            pes.Peso = xPeso.Text;

            await _connection.UpdateAsync(pes);
        }

      

        async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
        }

       
    }
}
