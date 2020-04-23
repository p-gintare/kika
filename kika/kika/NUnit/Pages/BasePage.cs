using OpenQA.Selenium;

namespace kika.NUnit.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
