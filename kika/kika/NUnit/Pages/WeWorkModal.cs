using OpenQA.Selenium;

namespace kika.NUnit.Pages
{
    public class WeWorkModal : BasePage
    {
        public WeWorkModal(IWebDriver driver) : base(driver)
        {
        }

        private By popupCloseButonSelector = By.CssSelector("#editable_popup[style*='display: block;'] .close");
        private IWebElement popupModalCloseElement => driver.FindElement(popupCloseButonSelector);

        public void Close()
        {
            popupModalCloseElement.Click();
        }
    }
}
