using System.Web.Mvc;
using NUnit.Framework;
using Sushi.Helpers.Enums;
using Sushi.Helpers.Extensions;

namespace sushi.htmlHelpers.Test.Helpers
{
    [TestFixture]
    public class PanelTest
    {
        
        [Test]
        public void TestDefault()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Panel().ToHtmlString();
            Assert.AreEqual(comparer, "<div class=\"well\"></div>");
        }

        [Test]
        public void TestName()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Panel().SetName("Name").ToHtmlString();
            Assert.AreEqual(comparer, "<div class=\"well\" name=\"Name\"></div>");
        }

        [Test]
        public void TestAddingComponentInsidePanel()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Panel()
                                        .AddElement(SushiExtension.Sushi(htmlHelper).Button())
                                        .ToHtmlString();
            Assert.AreEqual(comparer, "<div class=\"well\"><input class=\"btn btn-normal\" type=\"submit\" value=\"#EmptyValue\" /></div>");

        }

        [Test]
        public void TestAddingHtmlInsidePanel()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Panel()
                                        .AddInnerHTML("<input class=\"btn btn-normal\" type=\"submit\" value=\"#EmptyValue\" />")
                                        .ToHtmlString();
            Assert.AreEqual(comparer, "<div class=\"well\"><input class=\"btn btn-normal\" type=\"submit\" value=\"#EmptyValue\" /></div>");
        }

        [Test]
        public void TestMultipleComponentInsidePanel()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            using (SushiExtension.Sushi(htmlHelper).BeginBlock(LayoutType.Fixed))
            {
                htmlHelper.ViewContext.Writer.Write(SushiExtension.Sushi(htmlHelper).Button().ToString());
            }
            var comparer = FakeHtmlHelper.ResponseText;
            Assert.AreEqual(comparer, "<div class=\"fixed\"><input class=\"btn btn-normal\" type=\"submit\" value=\"#EmptyValue\" /></div>");

        }
    
    }
}
