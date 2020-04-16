using kika.NUnit.Pages;
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
        private KikaHomePage kikaHomePage;

        private By popupCloseButonSelector = By.CssSelector("#editable_popup[style*='display: block;'] .close");
        private IWebElement popupModalCloseElement => _driver.FindElement(popupCloseButonSelector);

        IWebElement cartItemPriceElement => _driver.FindElement(By.CssSelector("#cart_items .price"));
        IWebElement productNameElement => _driver.FindElement(By.CssSelector(".product_name"));
        IList<IWebElement> cartItemElementList => _driver.FindElements(By.CssSelector("#cart_items .item"));

        [SetUp]
        public void beforeTest()
        {
            var options = new ChromeOptions();
            options.AddArguments("incognito", "start-maximized");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //_driver.Url = "https://www.kika.lt/";
            kikaHomePage = new KikaHomePage(_driver);
            kikaHomePage.GoTo();
        }

        [Test]
        public void TestLogin()
        {
            popupModalCloseElement.Click();

            kikaHomePage
                .ClickOnLogin()
                    .EnterEmail("test@test.lt")
                    .EnterPassword("test123")
                    .ClickLogin()
                .AssertMenuExists();

          //  popupModalCloseElement.Click();
        }

        [Test]
        public void TestAddToCart()
        {
            popupModalCloseElement.Click();

            kikaHomePage
                .ClickOnLogin()
                .Login("test@test.lt", "test123").AssertMenuExists();

            popupModalCloseElement.Click();

            kikaHomePage.AssertCartBubleNumberIs("0");

            var price = kikaHomePage.GetFirstItemPrice();
            var name = kikaHomePage.GetFirstItemName();

            kikaHomePage
                .ClickFirstItemBuy()
                .ClickOnCart();

            kikaHomePage.Assert.AssertCartBubleNumberIs(1);

            Assert.IsTrue(cartItemPriceElement.Text.Contains(price), "Prices are not the same");
            Assert.AreEqual(name, productNameElement.Text);
            Assert.AreEqual(1, cartItemElementList.Count);
            
            
        }

        [TearDown]
        public void afterTest()
        {
            _driver.Quit();
        }
    }
}