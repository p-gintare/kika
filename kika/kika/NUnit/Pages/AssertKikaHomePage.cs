
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace kika.NUnit.Pages
{
    public class AssertKikaHomePage : BasePage
    {
        private IWebElement bubleCountElement;

        public AssertKikaHomePage(ChromeDriver driver, IWebElement bubble) : base(driver)
        {
            bubleCountElement = bubble;
        }

        public KikaHomePage AssertCartBubleNumberIs(int count)
        {
            Assert.AreEqual(count.ToString(), bubleCountElement.Text);
            return new KikaHomePage(driver);
        }
    }
}
