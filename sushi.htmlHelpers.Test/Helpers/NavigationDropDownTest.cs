using NUnit.Framework;
using System.Web.Mvc;
using Sushi.Extensions;
using Sushi.LinkHelper;
using Sushi.NavigationHelper;

namespace sushi.htmlHelpers.Test.Helpers
{

    [TestFixture]
    public class NavigationDropDownTest
    {
        [Test]
        public void TestDefaultWithHtmlHelper()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).NavigationDropDown().ToString();
            var result = "<ul class=\"nav\">" +
                         "<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\"><b class=\"caret\"></b></a>" +
                         "<ul class=\"dropdown-menu\">" +
                         "</ul>" +
                         "</li>" +
                         "</ul>";
            Assert.AreEqual(comparer, result);
        }

        [Test]
        public void TestDefaultStandalone()
        {
            var comparer = new NavigationDropDown().ToString();
            var result = "<ul class=\"nav\">" +
                         "<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\"><b class=\"caret\"></b></a>" +
                         "<ul class=\"dropdown-menu\">" +
                         "</ul>" +
                         "</li>" +
                         "</ul>";
            Assert.AreEqual(comparer, result);
        }

        [Test]
        public void TestSetCaption()
        {
            var comparer = new NavigationDropDown().SetCaption("Caption").ToString();
            var result = "<ul class=\"nav\">" +
                         "<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\">Caption<b class=\"caret\"></b></a>" +
                         "<ul class=\"dropdown-menu\">" +
                         "</ul>" +
                         "</li>" +
                         "</ul>";
            Assert.AreEqual(comparer, result);
        }

        [Test]
        public void TestAddLinkElement()
        {
            var comparer = new NavigationDropDown().SetCaption("Menu")
                                .AddLink(
                                    new Link("testid").SetCaption("Link Option").SetAction("#")
                                ).ToString();
            var result = "<ul class=\"nav\">" +
                         "<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\">Menu<b class=\"caret\"></b></a>" +
                         "<ul class=\"dropdown-menu\">" +
                         "<li><a href=\"#\" id=\"testid\">Link Option</a></li>" +
                         "</ul>" +
                         "</li>" +
                         "</ul>";
            Assert.AreEqual(comparer, result);
        }

        [Test]
        public void TestAddLinkElements()
        {
            var comparer = new NavigationDropDown().SetCaption("Menu")
                                .AddLink(
                                    new Link("testid").SetCaption("Link Option").SetAction("#")
                                )
                                .AddLink(
                                    new Link("testid2").SetCaption("Link Option 2").SetAction("#")
                                ).ToString();
            var result = "<ul class=\"nav\">" +
                         "<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\">Menu<b class=\"caret\"></b></a>" +
                         "<ul class=\"dropdown-menu\">" +
                         "<li><a href=\"#\" id=\"testid\">Link Option</a></li>" +
                         "<li><a href=\"#\" id=\"testid2\">Link Option 2</a></li>" +
                         "</ul>" +
                         "</li>" +
                         "</ul>";
            Assert.AreEqual(comparer, result);
        }

        [Test]
        public void TestAddHeaderAndLinks()
        {
            var comparer = new NavigationDropDown().SetCaption("Menu")
                                .AddHeader("Cabecera 1")
                                .AddLink(
                                    new Link("testid").SetCaption("Link Option").SetAction("#")
                                )
                                .AddLink(
                                    new Link("testid2").SetCaption("Link Option 2").SetAction("#")
                                ).ToString();
            var result = "<ul class=\"nav\">" +
                         "<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\">Menu<b class=\"caret\"></b></a>" +
                         "<ul class=\"dropdown-menu\">" +
                         "<li class=\"nav-header\">Cabecera 1</li>" +
                         "<li><a href=\"#\" id=\"testid\">Link Option</a></li>" +
                         "<li><a href=\"#\" id=\"testid2\">Link Option 2</a></li>" +
                         "</ul>" +
                         "</li>" +
                         "</ul>";
            Assert.AreEqual(comparer, result);
        }

        [Test]
        public void TestAddHeaderAndLinksAndSeparator()
        {
            var comparer = new NavigationDropDown().SetCaption("Menu")
                                .AddHeader("Cabecera 1")
                                .AddLink(
                                    new Link("testid").SetCaption("Link Option").SetAction("#")
                                )
                                .AddLink(
                                    new Link("testid2").SetCaption("Link Option 2").SetAction("#")
                                )
                                .AddSeparator()
                                .ToString();
            var result = "<ul class=\"nav\">" +
                         "<li class=\"dropdown\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\">Menu<b class=\"caret\"></b></a>" +
                         "<ul class=\"dropdown-menu\">" +
                         "<li class=\"nav-header\">Cabecera 1</li>" +
                         "<li><a href=\"#\" id=\"testid\">Link Option</a></li>" +
                         "<li><a href=\"#\" id=\"testid2\">Link Option 2</a></li>" +
                         "<li class=\"divider\"></li>" +
                         "</ul>" +
                         "</li>" +
                         "</ul>";
            Assert.AreEqual(comparer, result);
        }
    }
}

