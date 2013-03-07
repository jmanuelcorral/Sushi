using System.Web.Mvc;
using NUnit.Framework;
using Sushi.Helpers.NavigationHelper;

namespace sushi.htmlHelpers.Test.Helpers
{
    [TestFixture]
    public class NavigationTest
    {
        
        [Test]
        public void TestDefault()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = new Navigation().ToHtmlString();
            Assert.AreEqual(comparer, "<ul class=\"nav\"></ul>");
        }

        [Test]
        public void TestNavigationItem()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = new Navigation().AddElement(new NavigationItem()).ToHtmlString();
            Assert.AreEqual(comparer, "<ul class=\"nav\"><li></li></ul>");
        }

        [Test]
        public void TestNavigationItemHeader()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = new Navigation().AddElement(new NavigationItemHeader()).ToHtmlString();
            Assert.AreEqual(comparer, "<ul class=\"nav\"><li class=\"nav-header\"></li></ul>");
        }

        [Test]
        public void TestNavigationItemSeparator()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = new Navigation().AddSeparator().ToHtmlString();
            string result="<ul class=\"nav\"><li class=\"divider\"></li></ul>";
            Assert.AreEqual(comparer, result);
            
        }
        
    }
}