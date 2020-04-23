using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace kika.NUnit.Pages
{
    public class LoginModal : BasePage
    {
        public LoginModal(IWebDriver driver) : base(driver) { }

        IWebElement emailElement => driver.FindElement(By.CssSelector($"#login_form [name='email']"));
        IWebElement passwordElement => driver.FindElement(By.CssSelector($"#login_form [name='password']"));
        IWebElement loginButton => driver.FindElement(By.CssSelector($"#login_form .btn-primary"));

        public KikaHomePage Login(string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            var homePage = ClickLogin();
            homePage.Header.AssertMenuExists();
            return homePage;
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
            return new KikaHomePage(driver as ChromeDriver);
        }
    }
}
