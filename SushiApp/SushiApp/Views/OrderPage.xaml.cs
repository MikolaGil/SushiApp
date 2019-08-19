using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SushiApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SushiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {

        public OrderPage(EventArgs ev, ItemTappedEventArgs e)
        {
            ListElement element = e.Item as ListElement;

            Label label = new Label
            {
                Text = "Order Page"
            };
        }
    }
}