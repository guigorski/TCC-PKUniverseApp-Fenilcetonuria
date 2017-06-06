using App3.Models;
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
    public partial class Dietas : ContentPage
    {
        private List<Produto> _produto = new List<Produto>();
        private ObservableCollection<Pessoa> _pessoa;
        private SQLiteAsyncConnection _connection;
        private double x;
        private double aux;

        public Dietas(Produto produto = null, MeuItem meuitem = null)
        {

            InitializeComponent();

            var x = produto;
            addProduto(x);

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();


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
            await _connection.CreateTableAsync<Pessoa>();


            var pessoas = await _connection.Table<Pessoa>().ToListAsync();

            _pessoa = new ObservableCollection<Pessoa>(pessoas);

            var pe = _pessoa[0];


            if (pe.Peso == 00 || pe.Idade == 00)
            {
              var resposta =  await DisplayAlert("Ops, parece que voce ainda nao atualizou seus dados", "Deseja ir até a aba atualizar dados?", "Sim", "Não");
                if (resposta == true)
                {
                    await Navigation.PushAsync(new AtualizarDados());
                }
                else
                    await Navigation.PopAsync();
            }
            else
            {
                if (pe.Idade == 0.3)
                {
                    await DisplayAlert("Casou certinho", "", "ok");
                    var nMin = pe.Peso * 20;
                    var nMax = pe.Peso * 70;
                    xmin.Text = ("Qte Minima necessária de Fenilalanina: " + nMin);
                    xmax.Text = ("Qte Maxima necessária de Fenilalanina: " + nMax);
                }

              
               
            }

            base.OnAppearing();

            
             x = _produto[0].getFenilalanina();

           

            await DisplayAlert("oioioi" + x, "", "OK");
                xCalc.Text = x.ToString();

        

            await ProgressBar.ProgressTo(x, 900, Easing.Linear);
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
