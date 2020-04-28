using kika.NUnit.Utils;
using OpenQA.Selenium;

namespace kika.NUnit.Pages
{
    public class WeWorkModal
    {
        private By popupCloseButonSelector = By.CssSelector("#editable_popup[style*='display: block;'] .close");
        private IWebElement popupModalCloseElement => Driver.Current.FindElement(popupCloseButonSelector);

        public void Close()
        {
            popupModalCloseElement.Click();
        }
    }
}
