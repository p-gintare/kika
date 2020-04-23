using kika.NUnit.Pages;
using kika.NUnit.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace kika
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void TestLogin()
        {
            weWorkModal.Close();

            kikaHomePage.Header
                .ClickOnLogin()
                    .EnterEmail("test@test.lt")
                    .EnterPassword("test123")
                    .ClickLogin().Header
                .AssertMenuExists();
        } 
    }
}