using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarProdutos : ContentPage
    {
        private List<Grupos> _produto;
        
        public ListarProdutos()
        {
            InitializeComponent();

            

           

            _produto = new List<Grupos>
            {   
                new Grupos ("B", "B")
                {
                                    new Produto { Nome= "Bolacha Trakinas Chocolate e Morango",Proteinas= 1.8, Quantidade= "162g", ImageUrl= "http://www.zonasulatende.com.br/ImgProdutos/430_430/201257_71141.jpg"},
                },
                new Grupos("C", "C")
                {
                new Produto { Nome= "Chocolate Diamante Negro", Proteinas= 1.3, Quantidade= "100g", ImageUrl= "https://3.bp.blogspot.com/-gowJFPe1DWg/VxAyul5tM6I/AAAAAAABfq4/YUSr18lp1pwk7JUa_YJOYG5vcAJgzNlAwCLcB/s1600/diamante%2B2.jpg"},

                },
                new Grupos("F","F") {
                new Produto { Nome= "Farinha Lactea", Proteinas= 0.95, Quantidade= "210g", ImageUrl= "https://uploads.consultaremedios.com.br/health_and_beauty/variation/original/7891000252604.jpg?1481701361"},
                new Produto { Nome= "Farinha Lactea", Proteinas= 0.95 ,Quantidade= "400g", ImageUrl= "http://glicose.com.br/wp-content/uploads/2015/04/farinha-lactea.jpg"}
                }
                };

            listView.ItemsSource = _produto;
        }

      

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var produto = e.SelectedItem as Produto;
            var nome = produto.Nome;
            var fenil = ((produto.Proteinas * 10) / 3);
            DisplayAlert(produto.Nome, "Proteinas: " + produto.Proteinas + "\n Fenilanina: " + fenil , "OK");
        }
       
        private void Delete_Clicked(object sender, EventArgs e)
        {
            var produto = (sender as MenuItem).CommandParameter as Produto;
            
        }

        private void btn_Clicked(object sender, EventArgs e)
        {

            DisplayAlert("Item adicionado com sucesso!", "este item agora faz parte da sua dieta", "OK");
        }

        async void Voltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
