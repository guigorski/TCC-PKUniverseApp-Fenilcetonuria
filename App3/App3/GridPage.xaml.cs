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
    public partial class GridPage : ContentPage
    {
        public GridPage()
        {
            InitializeComponent();

            var imageSource = new UriImageSource { Uri = new Uri("http//:lorempixel.com/1920/1080/sports/7/") };
            image.Source = imageSource;
        }
    }
}
