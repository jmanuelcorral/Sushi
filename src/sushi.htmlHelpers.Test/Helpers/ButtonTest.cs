using System.Web.Mvc;
using NUnit.Framework;
using Sushi.Helpers.Enums;
using Sushi.Helpers.Extensions;

namespace sushi.htmlHelpers.Test.Helpers
{
    [TestFixture]
    public class ButtonTest
    {
        [Test]
        public void TestDefault()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Button().ToHtmlString();
            Assert.AreEqual(comparer, "<input class=\"btn btn-normal\" type=\"submit\" value=\"#EmptyValue\" />");
        }

       
        [Test]
        public void TestName()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Button().SetName("Name").ToHtmlString();
            Assert.AreEqual(comparer, "<input class=\"btn btn-normal\" name=\"Name\" type=\"submit\" value=\"#EmptyValue\" />");
        }

        [Test]
        public void TestAction()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Button().SetBehaviour(HtmlBehaviourType.Link).SetAction("Action").ToHtmlString();
            Assert.AreEqual(comparer, "<a class=\"btn btn-normal\" href=\"Action\" value=\"#EmptyValue\">#EmptyValue</a>");
        }

        [Test]
        public void TestSizes()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Button().SetSize(ButtonSize.normal).ToHtmlString();
            Assert.AreEqual(comparer, "<input class=\"btn btn-normal\" type=\"submit\" value=\"#EmptyValue\" />");
            var comparer1 = SushiExtension.Sushi(htmlHelper).Button().SetSize(ButtonSize.small).ToHtmlString();
            Assert.AreEqual(comparer1, "<input class=\"btn btn-small\" type=\"submit\" value=\"#EmptyValue\" />");
            var comparer2 = SushiExtension.Sushi(htmlHelper).Button().SetSize(ButtonSize.large).ToHtmlString();
            Assert.AreEqual(comparer2, "<input class=\"btn btn-large\" type=\"submit\" value=\"#EmptyValue\" />");
        }

        [Test]
        public void TestTypes()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Button().SetType(ButtonType.Primary).ToHtmlString();
            Assert.AreEqual(comparer, "<input class=\"btn btn-normal btn-primary\" type=\"submit\" value=\"#EmptyValue\" />");
            comparer = SushiExtension.Sushi(htmlHelper).Button().SetType(ButtonType.Danger).ToHtmlString();
            Assert.AreEqual(comparer, "<input class=\"btn btn-normal btn-danger\" type=\"submit\" value=\"#EmptyValue\" />");
            comparer = SushiExtension.Sushi(htmlHelper).Button().SetType(ButtonType.Default).ToHtmlString();
            Assert.AreEqual(comparer, "<input class=\"btn btn-normal\" type=\"submit\" value=\"#EmptyValue\" />");
            comparer = SushiExtension.Sushi(htmlHelper).Button().SetType(ButtonType.Info).ToHtmlString();
            Assert.AreEqual(comparer, "<input class=\"btn btn-normal btn-info\" type=\"submit\" value=\"#EmptyValue\" />");
            comparer = SushiExtension.Sushi(htmlHelper).Button().SetType(ButtonType.Success).ToHtmlString();
            Assert.AreEqual(comparer, "<input class=\"btn btn-normal btn-success\" type=\"submit\" value=\"#EmptyValue\" />");
        }

    }
}
