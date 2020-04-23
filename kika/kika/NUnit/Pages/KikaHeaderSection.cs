using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace kika.NUnit.Pages
{
    public class KikaHeaderSection : BasePage
    {
        public KikaHeaderSection(IWebDriver driver) : base(driver)
        {
        }
        IWebElement menuElement {
            get {
                try
                {
                    return driver.FindElement(By.CssSelector("#profile_menu.dropdown"));
                }
                catch(NoSuchElementException)
                {
                    return null;
                }catch(WebDriverException e)
                {
                    // kodas...
                    throw e;
                }
            }
        }

        IList<IWebElement> menuElements => driver.FindElements(By.CssSelector("#profile_menu.dropdown"));
        IWebElement loginElement => driver.FindElement(By.CssSelector(".need2login"));

        IWebElement searchElement => driver.FindElement(By.Id("quick_search_show"));

        IWebElement bubbleCountElement => driver.FindElement(By.CssSelector("#cart_info .cnt"));

        IWebElement cartElement => driver.FindElement(By.Id("cart_info"));

        public SearchPage ClickOnSearch()
        {
            searchElement.Click();
            return new SearchPage(driver);
        }

        public LoginModal ClickOnLogin()
        {
            loginElement.Click();
            return new LoginModal(driver);
        }

        public void AssertCartBubbleNumberIs(int count)
        {
            Assert.AreEqual(count.ToString(), bubbleCountElement.Text);
        }

        public void ClickOnCart()
        {
            cartElement.Click();
        }

        public void AssertMenuExists()
        {
            //kai turim lista
            Assert.IsTrue(menuElements.Count == 1);
            Assert.AreEqual(1, menuElements.Count);
            menuElements[0].Click();

            menuElement.Click();
            
            Assert.IsNotNull(menuElement, "User is not logged in");
        }


        public void AssertCartBubbleNumberIs(string count)
        {
            Assert.AreEqual(count, bubbleCountElement.Text);
        }
    }
}
