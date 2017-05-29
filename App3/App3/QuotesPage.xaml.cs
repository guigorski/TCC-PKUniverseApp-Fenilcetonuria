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
    public partial class QuotesPage : ContentPage
    {

        private string[] lista = new string[] { "Paulo: Não irá conseguir concluir o trabalho", "Siqueira: Está completamente atrasado",
            "Cecatto: Só quer saber de namorar", "Gianluca: Esta insuportavel", "Guilherme: Desorientado", "Sandro: Esta muito vagabundo", "Paula: Não esta levando a serio", "Japones: Não sabe nem descrever o tema",
        "Juliano: Iludido que irá conseguir", "Vaio: Escolheu o tema mais dificil da terra", "Daniel: Esta puxando muito o saco dos professores", "Didur: Gelatina", "Isaque: Está com serios problema"};
        private int index = 0;
        public QuotesPage()
        {
            InitializeComponent();
            CurrentQuote.Text = lista[index];
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            index++;
            if (index >= lista.Length)
            {
                index = 0;
            }
            CurrentQuote.Text = lista[index];
        }
    }
}
