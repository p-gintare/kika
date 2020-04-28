using kika.NUnit.Utils;
using OpenQA.Selenium;

namespace kika.NUnit.Pages
{
    public class KikaHomePage : BasePage
    {
        
        private const string FirstItemElementSelector = ".owl-item.active";
        IWebElement firstItemPriceElement => driver.FindElement(By.CssSelector(FirstItemElementSelector)).FindElement(By.CssSelector(".price"));
        IWebElement firstItemNameElement => driver.FindElement(By.CssSelector($"{FirstItemElementSelector} .name"));
        IWebElement buyButton => driver.FindElement(By.CssSelector($"{FirstItemElementSelector} .btn-primary"));

        public MenuSection Menu => new MenuSection();

        public KikaHomePage GoTo()
        {
            driver.Url = "https://www.kika.lt/";
            return this;
        }

        public KikaHomePage Login(User user)
        {
            Header
                .ClickOnLogin()
                .Login(user.Username, user.Password);
            return this;
        }

        public LoginModal ClickOnLogin()
        {
            Header.ClickOnLogin();
            return new LoginModal();
        }

        public string GetFirstItemPrice()
        {
            return firstItemPriceElement.Text;
        }

        public string GetFirstItemName()
        {
            return firstItemNameElement.Text.Trim();
        }

        public KikaHomePage ClickFirstItemBuy()
        {
            buyButton.Click();
            return this;
        }

        public CartPage ClickOnCart()
        {
            Header.ClickOnCart();
            return new CartPage();
        }
    }
}
