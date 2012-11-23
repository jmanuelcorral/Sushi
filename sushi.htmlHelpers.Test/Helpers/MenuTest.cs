using System.Web.Mvc;
using NUnit.Framework;
using Sushi.Enums;
using Sushi.Extensions;
using Sushi.FormHelper;
using Sushi.LinkHelper;
using Sushi.NavigationHelper;

namespace sushi.htmlHelpers.Test.Helpers
{
    [TestFixture]
    public class MenuTest
    {

        [Test]
        public void TestEmptyMenu()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Menu().ToHtmlString();
            Assert.AreEqual(comparer, "<div class=\"navbar\"><div class=\"navbar-inner\"></div></div>");
        }

        [Test]
        public void TestNavMenu()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Menu().AddNavigation(new Navigation("menu").AddLink(new Link("testlink"))).ToHtmlString();
            Assert.AreEqual(comparer, "<div class=\"navbar\"><div class=\"navbar-inner\"><ul class=\"nav\" id=\"Navigation1\"><li id=\"NavigationItemComponent1\"><a href=\"\" id=\"testlink\"></a></li></ul></div></div>");
        }

        [Test]
        public void TestThreeElementsNavMenu()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Menu().AddNavigation(
                new Navigation("menu")
                    .AddLink(new Link("testlink"))
                    .AddLink(new Link("testlink2"))
                    .AddLink(new Link("testlink3"))
                ).ToHtmlString();

            var resultExpected = "<div class=\"navbar\"><div class=\"navbar-inner\">" +
                                 "<ul class=\"nav\" id=\"Navigation1\">" +
                                 "<li id=\"NavigationItemComponent1\"><a href=\"\" id=\"testlink\"></a></li>" +
                                 "<li id=\"NavigationItemComponent2\"><a href=\"\" id=\"testlink2\"></a></li>" +
                                 "<li id=\"NavigationItemComponent3\"><a href=\"\" id=\"testlink3\"></a></li>" +
                                 "</ul>" +
                                 "</div></div>";
            Assert.AreEqual(comparer, resultExpected);
        }

        [Test]
        public void TestPositionFixedTopNavMenu()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Menu().SetPosition(MenuPosition.FixedTop).ToHtmlString();
            var resultExpected = "<div class=\"navbar navbar-fixed-top\"><div class=\"navbar-inner\"></div></div>";
            Assert.AreEqual(comparer, resultExpected);
        }

        [Test]
        public void TestPositionFixedBottomNavMenu()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Menu().SetPosition(MenuPosition.FixedBottom).ToHtmlString();
            var resultExpected = "<div class=\"navbar navbar-fixed-bottom\"><div class=\"navbar-inner\"></div></div>";
            Assert.AreEqual(comparer, resultExpected);
        }

        [Test]
        public void TestAddSearchForm()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Menu().AddSearchForm(new Form()).ToHtmlString();
            var resultExpected = "<div class=\"navbar navbar-fixed-top\"><div class=\"navbar-inner\">"+
                                 "<form class=\"navbar-search\" id=\"Form1\"></form>"+
                                 "</div></div>";
            Assert.AreEqual(comparer, resultExpected);
        }

        [Test]
        public void TestAddNormalForm()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Menu().AddNavForm(new Form()).ToHtmlString();
            var resultExpected = "<div class=\"navbar navbar-fixed-top\"><div class=\"navbar-inner\">" +
                                 "<form class=\"navbar-form\" id=\"Form1\"></form>" +
                                 "</div></div>";
            Assert.AreEqual(comparer, resultExpected);
        }

        [Test]
        public void TestAddDropDownMenu()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Menu()
                .AddNavigationDropDown(
                    new NavigationDropDown()
                        .SetCaption("File")
                        .AddLink(new Link().SetCaption("New").SetAction("#"))).ToHtmlString();

            var resultExpected = "<div class=\"navbar navbar-fixed-top\">"+
                                 "<div class=\"navbar-inner\">"+
                                 "<ul class=\"nav\">"+
                                 "<li class=\"dropdown\">" +
                                    "<a class=\"dropdown-toggle\" data-toggle=\"dropdown\">File<b class=\"caret\"></b></a>" +
                                    "<ul class=\"dropdown-menu\">"+
                                        "<li><a href=\"#\">New</a></li>" +
                                    "</ul>"+
                                "</li>"+
                                "</ul>"+
                                "</div></div>";
            Assert.AreEqual(comparer, resultExpected);
        }

        [Test]
        public void TestAddDropDownIconMenu()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Menu()
                .AddNavigationDropDown(
                    new NavigationDropDown()
                        .SetCaption("File").SetIcon(Icon.IconFile, IconColor.Black)
                        .AddLink(new Link().SetCaption("New").SetAction("#"))).ToHtmlString();

            var resultExpected = "<div class=\"navbar navbar-fixed-top\">" +
                                 "<div class=\"navbar-inner\">" +
                                 "<ul class=\"nav\">" +
                                 "<li class=\"dropdown\">" +
                                    "<a class=\"dropdown-toggle\" data-toggle=\"dropdown\"><i class=\"icon-file\"></i>File<b class=\"caret\"></b></a>" +
                                    "<ul class=\"dropdown-menu\">" +
                                        "<li><a href=\"#\">New</a></li>" +
                                    "</ul>" +
                                "</li>" +
                                "</ul>" +
                                "</div></div>";
            Assert.AreEqual(comparer, resultExpected);
        }
    }
}
