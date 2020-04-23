using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace kika.NUnit.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        IWebElement searchInputElement => driver.FindElement(By.CssSelector("#quick_search.active [name='search']"));
        IWebElement searchButton => driver.FindElement(By.CssSelector("#quick_search [type='submit']"));

        IList<IWebElement> productElementList => driver.FindElements(By.CssSelector(".product_element"));
        IList<IWebElement> productTitleElementList => driver.FindElements(By.CssSelector(".product_element .title2"));

        public SearchPage Search(string text)
        {
            searchInputElement.SendKeys(text);
            searchButton.Click();
            return this;
        }

        public void AssertSearchResultsContainsTesxt(string text)
        {
            var count = productElementList.Count;
            Assert.IsTrue(count > 0, $"Search result count is: ${count}");
            Assert.AreEqual(count, productTitleElementList.Count);
           
            for(var  i = 0; i > productTitleElementList.Count; i++)
            {
                var title = productTitleElementList[i].Text;
                Assert.IsTrue(title.Contains(text, StringComparison.CurrentCultureIgnoreCase),
                   $"Product title should contains: ${text}, but instead title is ${title}");
            }

            foreach(var productTitleElement in productTitleElementList)
            {
                Assert.IsTrue(productTitleElement.Text.Contains(text, StringComparison.CurrentCultureIgnoreCase),
                    $"Product title should contains: ${text}, but instead title is ${productTitleElement.Text}");
            }
            
        }
    }
}
