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
        private List<ListaDietas> _produto = new List<ListaDietas>();
        private ObservableCollection<Pessoa> _pessoa;
        private ObservableCollection<ListaDietas> lista;
        private SQLiteAsyncConnection _connection;
        private double x;
        private double nMin, nMax;

        public Dietas(IProduto produto = null)
        {

            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();


            //CriaProduto(produto);
            if (produto != null)
            {
                var x = CriaProduto(produto);
                _produto.Add(x);
            }
          
            
         

           
        }

        
        public ListaDietas CriaProduto(IProduto produto)
        {
            var nome = produto.Nome;
            var prot = produto.Proteinas;

            var addprod = new ListaDietas { Nome = nome, Proteinas = prot };

            return addprod;       
            
        }
       

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Pessoa>();

            await _connection.CreateTableAsync<ListaDietas>();

            await _connection.InsertAllAsync(_produto);

            var produtos = await _connection.Table<ListaDietas>().ToListAsync();

            lista = new ObservableCollection<ListaDietas>(produtos);


            listView.ItemsSource = lista;

            GeraCalculos();

            base.OnAppearing();

              

            for (int i = 0; i < lista.Count; i++)
            {
                x += lista[i].getFenilalanina();

            }

            double valorNormalizado = x / 300; 

            xCalc.Text = x.ToString();

            await DisplayAlert(valorNormalizado.ToString(), x.ToString(), nMax.ToString());

            await ProgressBar.ProgressTo(valorNormalizado, 900, Easing.Linear);
        }

        async void GeraCalculos()
        {
            var pessoas = await _connection.Table<Pessoa>().ToListAsync();

            _pessoa = new ObservableCollection<Pessoa>(pessoas);

            var pe = _pessoa[0];


            if (pe.Peso == 00 || pe.Idade == 00)
            {
                var resposta = await DisplayAlert("Ops, parece que voce ainda nao atualizou seus dados", "Deseja ir até a aba atualizar dados?", "Sim", "Não");
                if (resposta == true)
                {
                    await Navigation.PushAsync(new AtualizarDados());
                }
                else
                    await Navigation.PopAsync();
            }
            else
            {
                
                if (pe.Idade > 0.1 && pe.Idade <= 0.5)
                {
                    nMin = pe.Peso * 20;
                    nMax = pe.Peso * 70;
                }
                else if (pe.Idade > 0.5 && pe.Idade <= 1)
                {
                    nMin = pe.Peso * 15;
                    nMax = pe.Peso * 50;
                }
                else if (pe.Idade > 1 && pe.Idade <= 4)
                {
                    nMin = pe.Peso * 15;
                    nMax = pe.Peso * 40;
                }
                else if (pe.Idade > 4 && pe.Idade <= 7)
                {
                    nMin = pe.Peso * 15;
                    nMax = pe.Peso * 35;
                }
                else if (pe.Idade > 7 && pe.Idade <= 15)
                {
                    nMin = pe.Peso * 15;
                    nMax = pe.Peso * 30;
                }
                else
                {
                    nMin = pe.Peso * 10;
                    nMax = pe.Peso * 30;
                }
                xmin.Text = ("Qte Minima necessária de Fenilalanina: " + nMin);
                xmax.Text = ("Qte Maxima necessária de Fenilalanina: " + nMax);

            }
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
            var produto = e.SelectedItem as ListaDietas;
            var nome = produto.Nome;
            var proteina = produto.Proteinas;
            var fenil = produto.getFenilalanina();
         
            DisplayAlert("Adicionar ao Acompanhamento diário", "Nome: " + nome + "\nProteina: " + proteina + "\nFenilanina: " + fenil, "OK");


        }

        async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MeusItens());

        }

        async void Del_Clicked(object sender, EventArgs e)
        {
           var resposta = await DisplayAlert("Deseja realmente deletar tudo?", "Essa ação não pode ser desfeita", "Aceitar", "Cancelar");
            if (resposta == true)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    await _connection.DeleteAsync(lista[i]);
                }
               await Navigation.PopAsync();
            }
        }
    }
}
