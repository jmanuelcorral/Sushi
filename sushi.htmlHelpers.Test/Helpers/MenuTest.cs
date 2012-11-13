using System.Web.Mvc;
using NUnit.Framework;

namespace sushi.htmlHelpers.Test.Helpers
{
    [TestFixture]
    public class MenuTest
    {
        /*
        [Test]
        public void TestDefault()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Menu().ToHtmlString();
            Assert.AreEqual(comparer,
                            "<div class=\"navbar-inner\"><div class=\"navbar\"><div class=\"container\"></div></div></div>");
        }

        [Test]
        public void TestPositions()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Menu().SetPosition(MenuPosition.FixedTop).ToHtmlString();
            Assert.AreEqual(comparer,
                            "<div class=\"navbar-inner\"><div class=\"navbar\"><div class=\"container\"></div></div></div>");
            comparer = SushiExtension.Sushi(htmlHelper).Menu().SetPosition(MenuPosition.UnFixed).ToHtmlString();
            Assert.AreEqual(comparer,
                            "<div class=\"navbar-inner\"><div class=\"navbar\"><div class=\"container\"></div></div></div>");
            Assert.Inconclusive("Falta por poner en marcha");
        }

        [Test]
        public void TestAddingLink()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Menu()
                                                        .AddElement(SushiExtension.Sushi(htmlHelper).Link())
                                                        .ToHtmlString();
            Assert.AreEqual(comparer, "<div class=\"navbar-inner\"><div class=\"navbar\"><div class=\"container\"><a href=\"\" id=\"SushiLink1\"></a></div></div></div>");
        }

        [Test]
        public void TestAddingSearch()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Menu()
                                                        .AddElement(SushiExtension.Sushi(htmlHelper).MenuSearchBoxItem())
                                                        .ToHtmlString();
            Assert.AreEqual(comparer, "<div class=\"navbar-inner\"><div class=\"navbar\"><div class=\"container\"><form class=\"navbar-search pull-left\" id=\"SushiForm1\"><input class=\"span1 search-query\" id=\"SushiInput1\" name=\"\" type=\"text\" value=\"\"></input></form></div></div></div>");
        }

        [Test]
        public void TestAddingNavigation()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Menu().AddElement(SushiExtension.Sushi(htmlHelper).Navigation()).ToHtmlString();
            Assert.AreEqual(comparer, "<div class=\"navbar-inner\"><div class=\"navbar\"><div class=\"container\"><ul class=\"nav\" id=\"SushiNavigation1\"></ul></div></div></div>");
        }
         */
    }
}
