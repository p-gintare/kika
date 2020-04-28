using kika.NUnit.Pages;
using kika.NUnit.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;

namespace kika.NUnit.Tests
{
    public abstract class BaseTest
    {
        protected KikaHomePage kikaHomePage;
        protected WeWorkModal weWorkModal;
        protected ProductListingPage productPage;
        protected CartPage cartPage;

        [SetUp]
        public void BeforeTest()
        {
            Driver.Init();
            InitPages();
            kikaHomePage.GoTo();
        }

        private void InitPages()
        {
            kikaHomePage = new KikaHomePage();
            weWorkModal = new WeWorkModal();
            productPage = new ProductListingPage();
            cartPage = new CartPage();
        }

        [TearDown]
        public void QuitDriver()
        {
            MakeScreenshotOnTestFailure();
            Driver.Quit();
        }

        protected void MakeScreenshotOnTestFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                DoScreenshot();
            }
        }

        protected void loginWithDefaultUser()
        {
            LoginWithUser(User.DefaultKikaUser);
            
        }

        protected void LoginWithUser(User user)
        {
            LoginWithUser(user.Username, user.Password);
        }

        protected void LoginWithUser(string username, string password)
        {
            weWorkModal.Close();

            kikaHomePage
                .ClickOnLogin()
                .Login(username, password);
        }

        protected void DoScreenshot()
        {
            Screenshot screenshot = Driver.Current.TakeScreenshot();
            string screenshotPath = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotPath);
            string screenshotFile = Path.Combine(screenshotPath, $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now.ToString("yy-MM-dd HH:mm:ss")}.png");

            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            Console.WriteLine("screenshot: file://" + screenshotFile);

            // Add that file to NUnit results
            TestContext.AddTestAttachment(screenshotFile, "My Screenshot");
            //return screenshot.AsByteArray;
        }
    }
}
