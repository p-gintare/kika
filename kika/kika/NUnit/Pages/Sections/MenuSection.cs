using kika.NUnit.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace kika.NUnit.Pages
{
    public class MenuSection : BasePage
    {
        private IWebElement dogMenuElement => driver.FindElement(By.CssSelector("#mega_menu .dog .title a"));
        private IWebElement dogToyMenuElement => driver.FindElement(By.CssSelector("#mega_menu .dog.active [href$='/sunims/zaislai/']"));

        public ProductListingPage NavigateToDogToys(NavigationType type = NavigationType.Native)
        {
            switch (type)
            {
                case NavigationType.Native:
                    {
                        var actions = new Actions(driver);
                        actions.MoveToElement(dogMenuElement).Build().Perform();
                        actions.MoveToElement(dogToyMenuElement).Click().Build().Perform();
                        break;
                    }

                case NavigationType.Url:
                    Navigation.GoToDogToysPage();
                    break;
            }
            return new ProductListingPage();
        }
    }

    public enum NavigationType
    {
        Url, 
        Native
    }
}
