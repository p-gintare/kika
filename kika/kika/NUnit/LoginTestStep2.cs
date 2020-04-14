using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace kika
{
    public class LoginTestStep2
    {
        private IWebDriver _driver;

        [SetUp]
        public void initDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("incognito", "start-maximized");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [SetUp]
        public void openKika() {
            _driver.Url = "https://www.kika.lt/";
        }

        [Test]
        public void TestLogin()
        {
            var modalCloseElement = _driver.FindElement(By.CssSelector("#editable_popup[style*='display: block;'] .close"));
            modalCloseElement.Click();

            var loginElement = _driver.FindElement(By.CssSelector(".need2login"));
            loginElement.Click();

            var emailElement = _driver.FindElement(By.CssSelector("#login_form [name='email']"));
            emailElement.SendKeys("test@test.lt");
            var passwordElement = _driver.FindElement(By.CssSelector("#login_form [name='password']"));
            passwordElement.SendKeys("test123");
            var loginButton = _driver.FindElement(By.CssSelector("#login_form .btn-primary"));
            loginButton.Click();

            // driver.FindElement(By.CssSelector("#editable_popup[style*='display: block;'] .close")).Click();
            var profileElement = _driver.FindElement(By.CssSelector("#profile_menu.dropdown"));
            Assert.IsNotNull(profileElement, "User is not logged in");
        }

        [TearDown]
        public void afterTest()
        {
            _driver.Quit();
        }
    }
}