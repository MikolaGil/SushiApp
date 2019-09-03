using System.Text;
using Xamarin.Forms;

namespace SushiApp.Extension
{
    public static class LabelTM
    {
        public static string AddTrademark(this Label label, string str)
        {
            StringBuilder stringTM = new StringBuilder(str);
            stringTM.Append("™");
            return stringTM.ToString();
        }
    }
}
