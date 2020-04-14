using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace kika
{
    public class LoginTestStep1
    {
        private ChromeDriver _driver;

        private By popupCloseButonSelector = By.CssSelector("#editable_popup[style*='display: block;'] .close");
        private const string LoginId = "login_form";


        private IWebElement popupModalElement => _driver.FindElement(popupCloseButonSelector);
        private IList<IWebElement> list => _driver.FindElements(By.CssSelector(".need2login"));
        IWebElement emailElement => _driver.FindElementByCssSelector($"#{LoginId} [name='email']");
        IWebElement passwordElement => _driver.FindElementByCssSelector($"#{LoginId} [name='password']");
        IWebElement menuElement => _driver.FindElementByCssSelector("#profile_menu.dropdown");
        IWebElement p
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#editable_popup[style*='display: block;'] .close"));
            }
        }

        [SetUp]
        public void beforeTest()
        {
            var options = new ChromeOptions();
            options.AddArguments("incognito", "start-maximized");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            _driver.Url = "https://www.kika.lt/";
        }

        [Test]
        public void TestLogin()
        {
            popupModalElement.Click();
            list[0].Click();
            emailElement.SendKeys("test@test.lt");

            
            passwordElement.SendKeys("test123");
            _driver.FindElementByCssSelector("#login_form .btn-primary").Click();

            // driver.FindElement(By.CssSelector("#editable_popup[style*='display: block;'] .close")).Click();
            
            Assert.IsNotNull(menuElement, "User is not logged in");
        }

        [Test]
        public void TestAddToCart()
        {
             
            popupModalElement.Click();
            list[0].Click();
            
            emailElement.SendKeys("test@test.lt");

            _driver.FindElementByCssSelector("#login_form [name='password']").SendKeys("test123");
            _driver.FindElementByCssSelector("#login_form .btn-primary").Click();

            _driver.FindElement(By.CssSelector("#editable_popup[style*='display: block;'] .close")).Click();
            
            Assert.IsNotNull(menuElement, "User is not logged in");

            _driver.FindElement(By.CssSelector(".owl-item.active"));
            var price = _driver.FindElement(By.CssSelector(".owl-item.active")).FindElement(By.CssSelector(".price")).Text;
            var name = _driver.FindElement(By.CssSelector(".owl-item.active .name")).Text.Trim();
            _driver.FindElement(By.CssSelector(".owl-item.active .btn-primary")).Click();

            _driver.FindElement(By.Id("cart_info")).Click();
            _driver.FindElement(By.Id("cart_items")).FindElements(By.CssSelector(".item"))[2].FindElement(By.TagName("a"));
            Assert.IsTrue(_driver.FindElement(By.CssSelector("#cart_items .price")).Text.Contains(price), "Prices are not the same");
            Assert.AreEqual(name, _driver.FindElement(By.CssSelector(".product_name")).Text);
            Assert.AreEqual(1, _driver.FindElements(By.CssSelector("#cart_items .item")).Count);
            Assert.AreEqual("1", _driver.FindElement(By.CssSelector("#cart_info .cnt")).Text);
        }

        [TearDown]
        public void afterTest()
        {
            _driver.Quit();
        }
    }
}