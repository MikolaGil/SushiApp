namespace SushiApp.Delegates
{
    delegate double GetPrice(double num, double text);
    public class Sum { 
        static public double FullPrice(double sushiPrice, double deliveryPrice)
        {
            return sushiPrice + deliveryPrice;
        }
        GetPrice totalPrice = FullPrice;
    }
}
