using kika.NUnit.Utils;
using OpenQA.Selenium;

namespace kika.NUnit.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public KikaHeaderSection Header => new KikaHeaderSection();
        protected BasePage()
        {
            driver = Driver.Current;
        }
    }
}
