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
            var pe = new Pessoa { Nome = "Usuario", Peso = 00, Idade = 00 };

            await _connection.CreateTableAsync<Pessoa>();

           
            var pessoas = await _connection.Table<Pessoa>().ToListAsync();
            
            _pessoa = new ObservableCollection<Pessoa>(pessoas);

            if (_pessoa.Count == 0)
            {
                _pessoa.Add(pe);
                await _connection.InsertAsync(pe);
            }
            listView.ItemsSource = _pessoa;

            
            var pes = _pessoa[0];
            xNome.Text = pes.Nome;
            var PesoToString = pes.Peso.ToString();
            xPeso.Text = PesoToString;
            var IdadeToString = pes.Idade.ToString();
            xData.Text = IdadeToString;


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
            var pes = _pessoa[0];
            pes.Nome = xNome.Text;
            var PesoToInt = Double.Parse(xPeso.Text);
            pes.Peso = PesoToInt;
            var IdadeToInt = Double.Parse(xData.Text);
            pes.Idade = IdadeToInt;
            await _connection.UpdateAsync(pes);
            await DisplayAlert("Dados Atulizados com Sucesso!", "Os dados foram atualizados e já estão disponiveis para os calculos", "OK");
            await Navigation.PopAsync();
        }



       

       
    }
}
