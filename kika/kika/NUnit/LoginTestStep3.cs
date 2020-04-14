using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace kika
{
    public class LoginTestStep3
    {
        private ChromeDriver _driver;

        private By popupCloseButonSelector = By.CssSelector("#editable_popup[style*='display: block;'] .close");
        private IWebElement popupModalCloseElement => _driver.FindElement(popupCloseButonSelector);

        private const string LoginId = "login_form";
        private IWebElement loginElement => _driver.FindElement(By.CssSelector(".need2login"));
        IWebElement emailElement => _driver.FindElementByCssSelector($"#{LoginId} [name='email']");
        IWebElement passwordElement => _driver.FindElementByCssSelector($"#{LoginId} [name='password']");
        IWebElement loginButton => _driver.FindElementByCssSelector($"#{LoginId} .btn-primary");

        IWebElement menuElement => _driver.FindElementByCssSelector("#profile_menu.dropdown");

        private const string FirstItemElementSelector = ".owl-item.active";
        IWebElement firstItemPriceElement => _driver.FindElement(By.CssSelector(FirstItemElementSelector)).FindElement(By.CssSelector(".price"));
        IWebElement firstItemNameElement => _driver.FindElement(By.CssSelector($"{FirstItemElementSelector} .name"));
        IWebElement buyButton => _driver.FindElement(By.CssSelector($"{FirstItemElementSelector} .btn-primary"));

        IWebElement cartElement => _driver.FindElement(By.Id("cart_info"));
        IWebElement cartItemPriceElement => _driver.FindElement(By.CssSelector("#cart_items .price"));
        IWebElement productNameElement => _driver.FindElement(By.CssSelector(".product_name"));
        IList<IWebElement> cartItemElementList => _driver.FindElements(By.CssSelector("#cart_items .item"));
        IWebElement bubleCountElement => _driver.FindElement(By.CssSelector("#cart_info .cnt"));
        IWebElement example
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
            popupModalCloseElement.Click();

            loginElement.Click();

            emailElement.SendKeys("test@test.lt");
            passwordElement.SendKeys("test123");
            loginButton.Click();

            popupModalCloseElement.Click();
            
            Assert.IsNotNull(menuElement, "User is not logged in");
        }

        [Test]
        public void TestAddToCart()
        {
            popupModalCloseElement.Click();

            loginElement.Click();

            emailElement.SendKeys("test@test.lt");
            passwordElement.SendKeys("test123");
            loginButton.Click();

            popupModalCloseElement.Click();

            Assert.IsNotNull(menuElement, "User is not logged in");

            var price = firstItemPriceElement.Text;
            var name = firstItemNameElement.Text.Trim();
            buyButton.Click();

            cartElement.Click();

            Assert.IsTrue(cartItemPriceElement.Text.Contains(price), "Prices are not the same");
            Assert.AreEqual(name, productNameElement.Text);
            Assert.AreEqual(1, cartItemElementList.Count);
            Assert.AreEqual("1", bubleCountElement.Text);
        }

        [TearDown]
        public void afterTest()
        {
            _driver.Quit();
        }
    }
}