using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace kika
{
    public class LoginTestBasic : BaseTest
    {
        [Test]
        public void TestLogin()
        {
            var options = new ChromeOptions();
            options.AddArguments("incognito", "start-maximized");
            var driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
           
            driver.Url = "https://www.kika.lt/";
            // driver.Navigate().GoToUrl("https://www.kika.lt/");
            
            driver.FindElement(By.CssSelector("#editable_popup[style*='display: block;'] .close")).Click();
            driver.FindElement(By.CssSelector(".need2login")).Click();
            driver.FindElementByCssSelector("#login_form [name='email']").SendKeys("test@test.lt");
            driver.FindElementByCssSelector("#login_form [name='password']").SendKeys("test123");
            driver.FindElementByCssSelector("#login_form .btn-primary").Click();

            // driver.FindElement(By.CssSelector("#editable_popup[style*='display: block;'] .close")).Click();
            Assert.IsNull(driver.FindElement(By.CssSelector(".need2login")), "Neprisijunge!!");
            Assert.IsNotNull(driver.FindElementByCssSelector("#profile_menu.dropdown"), "User is not logged in");
            Assert.That(driver.FindElementByCssSelector("#profile_menu.dropdown"), Is.Not.Null);

            driver.Quit();
        }
    }
}