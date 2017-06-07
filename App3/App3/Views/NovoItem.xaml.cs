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
    public partial class NovoItem : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        public NovoItem()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();


        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Produto>();
        }

            async void enviar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var getProteina = Double.Parse(xProteina.Text);
                var getCalorias = Double.Parse(xCalorias.Text);
                var pes = new Produto { Nome = xNomeProduto.Text, Marca = xMarca.Text, Proteinas = getProteina, Quantidade = xQuantidade.Text, Calorias = getCalorias };

                if (pes.Nome == null)
                {
                    await DisplayAlert("Ops, O Produto precisa ter um nome", "", "Ok");
                }
                else
                {
                    await DisplayAlert("Produto adicionado com sucesso!", "Agora este produto faz parte da sua base de dados para os calculos", "OK");
                    await _connection.InsertAsync(pes);
                }
                await Navigation.PopAsync();
            }
            catch {
               await DisplayAlert("Ops, Algo deu errado!", "Talvez você tenha inserido algumas palavras nos campos: Proteinas ou Calorias", "OK");
            }
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PopAsync();
        }
    }
}
