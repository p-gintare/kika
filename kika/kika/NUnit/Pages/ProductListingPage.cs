using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace kika.NUnit.Pages
{
    public class ProductListingPage : BasePage
    {
        private IWebElement productElement => driver.FindElement(By.CssSelector(".product_element"));

        private IWebElement ProductTitleElement(IWebElement productElement) => productElement.FindElement(By.CssSelector(".title"));
        private IWebElement ProductPriceElement(IWebElement productElement) => productElement.FindElement(By.CssSelector(".price"));
        private IWebElement ProductAddToCartButton(IWebElement productElement) => productElement.FindElement(By.CssSelector(".btn-primary"));

        public string GetProductTitle()
        {
            return ProductTitleElement(productElement).Text.Trim();
        }

        public string GetProductPrice()
        {
            return ProductPriceElement(productElement).Text.Trim();
        }

        public ProductListingPage AddProductToCart()
        {
            ProductAddToCartButton(productElement).Click();
            return this;
        }
    }
}
