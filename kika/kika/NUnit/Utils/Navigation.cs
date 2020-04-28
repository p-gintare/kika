using kika.NUnit.Pages;


namespace kika.NUnit.Utils
{
    public class Navigation
    {
        public static ProductListingPage GoToDogToysPage()
        {
            Driver.Current.Url = "https://www.kika.lt/katalogas/sunims/zaislai/";
            return new ProductListingPage();
        }
    }
}
