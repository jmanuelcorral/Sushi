using System.Web.Mvc;
using NUnit.Framework;
using Sushi.Extensions;

namespace sushi.htmlHelpers.Test.Helpers
{
    [TestFixture]
    public class NavigationTest
    {
        
        [Test]
        public void TestDefault()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Navigation().ToHtmlString();
            Assert.AreEqual(comparer, "<ul class=\"nav\" id=\"NavigationComponent1\"></ul>");
        }

        [Test]
        public void TestNavigationItem()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Navigation()
                                                            .AddElement(SushiExtension.Sushi(htmlHelper).NavigationItem()).ToHtmlString();
            Assert.AreEqual(comparer, "<ul class=\"nav\" id=\"NavigationComponent1\"><li id=\"NavigationItemComponent1\"></li></ul>");
        }

        [Test]
        public void TestNavigationItemHeader()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Navigation()
                                                            .AddElement(SushiExtension.Sushi(htmlHelper).NavigationItemHeader()).ToHtmlString();
            Assert.AreEqual(comparer, "<ul class=\"nav\" id=\"NavigationComponent1\"><li class=\"nav-header\"></li></ul>");
        }

        [Test]
        public void TestNavigationItemSeparator()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            //var comparer = SushiExtension.Sushi(htmlHelper).Navigation().
            Assert.Inconclusive("Falta la funcionalidad");
        }
        
    }
}