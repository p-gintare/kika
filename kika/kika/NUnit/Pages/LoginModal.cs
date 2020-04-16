using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace kika.NUnit.Pages
{
    public class LoginModal
    {
        private ChromeDriver driver;

        public LoginModal(ChromeDriver driver)
        {
            this.driver = driver;
        }

        IWebElement emailElement => driver.FindElementByCssSelector($"#login_form [name='email']");
        IWebElement passwordElement => driver.FindElementByCssSelector($"#login_form [name='password']");
        IWebElement loginButton => driver.FindElementByCssSelector($"#login_form .btn-primary");

        public KikaHomePage Login(string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            return ClickLogin();
        }

        public LoginModal EnterEmail(string email)
        {
            emailElement.SendKeys(email);
            return this;
        }

        public LoginModal EnterPassword(string password)
        {
            passwordElement.SendKeys(password);
            return this;
        }

        public KikaHomePage ClickLogin()
        {
            loginButton.Click();
            return new KikaHomePage(driver);
        }
    }
}
