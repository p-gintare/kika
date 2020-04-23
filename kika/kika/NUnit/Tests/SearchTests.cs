using kika.NUnit.Utils;
using NUnit.Framework;

namespace kika.NUnit.Tests
{
    public class SearchTests : BaseTest
    {
        [SetUp]
        public void Before()
        {
            weWorkModal.Close();
            kikaHomePage.Login(User.DefaultKikaUser);
        }

        [Test]
        public void TestSearchWorks()
        {
            var searchValue = "canin";
            kikaHomePage.Header
                .ClickOnSearch()
                .Search(searchValue)
                .AssertSearchResultsContainsTesxt(searchValue);
        }
    }
}
