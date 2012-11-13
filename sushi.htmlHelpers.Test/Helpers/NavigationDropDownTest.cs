using NUnit.Framework;
using System.Web.Mvc;

namespace sushi.htmlHelpers.Test.Helpers
{
     /*
     Html.Sushi().NavigationDropDown()
        .SetMenuValue("Componentes")
        .AddDropDownHeaderElement("Botones")
        .AddDropDownLinkElement(Html.Sushi().Link().SetAction("/home/buttons").SetCaption("Botones Normales"))
        .AddDropDownLinkElement(Html.Sushi().Link().SetAction("#").SetCaption("Botones Desplegables"))
        .AddDropDownLinkElement(Html.Sushi().Link().SetAction("#").SetCaption("Grupos"))
        .AddDropDownLinkElement(Html.Sushi().Link().SetAction("#").SetCaption("Paginadores"))
        .AddSeparator()
        .AddDropDownHeaderElement("Navegacion")
        .AddDropDownLinkElement(Html.Sushi().Link().SetAction("#").SetCaption("Menu"))
        .AddDropDownLinkElement(Html.Sushi().Link().SetAction("#").SetCaption("Pills"))
        .AddDropDownLinkElement(Html.Sushi().Link().SetAction("#").SetCaption("Tabs"))
        .AddDropDownLinkElement(Html.Sushi().Link().SetAction("#").SetCaption("Stacked"))
        .AddDropDownLinkElement(Html.Sushi().Link().SetAction("#").SetCaption("BreadCrumbs"))
        .AddSeparator()
        .AddDropDownHeaderElement("Formularios")
        .AddDropDownLinkElement(Html.Sushi().Link().SetAction("#").SetCaption("En linea"))
        .AddDropDownLinkElement(Html.Sushi().Link().SetAction("#").SetCaption("Embebidos"))
     */


    [TestFixture]
    public class NavigationDropDownTest
    {
        /*
        [Test]
        public void TestDefault()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer =
                SushiExtension.Sushi(htmlHelper).NavigationDropDown().ToString();
            Assert.AreEqual(comparer, "<li class=\"dropdown\" id=\"SushiNavigationItem1\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" href=\"\" id=\"SushiLink1\"><b class=\"caret\"></b></a></li>");
        }

        [Test]
        public void TestMenuValue()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).NavigationDropDown().SetMenuValue("MenuCaption").ToString();
            Assert.AreEqual(comparer, "<li class=\"dropdown\" id=\"SushiNavigationItem1\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" href=\"\" id=\"SushiLink1\">MenuCaption<b class=\"caret\"></b></a></li>");
        }

      
        [Test]
        public void TestDropDownHeaderElement()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).NavigationDropDown().AddDropDownHeaderElement("DDHeader").ToString();
            Assert.AreEqual(comparer, "<li class=\"dropdown\" id=\"SushiNavigationItem1\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" href=\"\" id=\"SushiLink1\"><b class=\"caret\"></b></a><ul class=\"dropdown-menu\" id=\"SushiDropDown1\"><li id=\"SushiDropDownHeaderItem1\"><li class=\"nav-header\" id=\"SushiNavigationItemHeader1\">DDHeader</li></li></ul></li>");
        }

        [Test]
        public void TestDropDownLinkElement()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).NavigationDropDown().AddDropDownLinkElement(SushiExtension.Sushi(htmlHelper).Link()).ToString();
            Assert.AreEqual(comparer, "<li class=\"dropdown\" id=\"SushiNavigationItem1\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" href=\"\" id=\"SushiLink1\"><b class=\"caret\"></b></a><ul class=\"dropdown-menu\" id=\"SushiDropDown1\"><li id=\"SushiDropDownHeaderItem1\"><a href=\"\" id=\"SushiLink2\"></a></li></ul></li>");
        }


        [Test]
        public void TestSeparator()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).NavigationDropDown().AddSeparator().ToString();
            Assert.AreEqual(comparer, "<li class=\"dropdown\" id=\"SushiNavigationItem1\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" href=\"\" id=\"SushiLink1\"><b class=\"caret\"></b></a><ul class=\"dropdown-menu\" id=\"SushiDropDown1\"><li id=\"SushiDropDownHeaderItem1\"><li class=\"divider\"></li></li></ul></li>");
        }
        */
    }
}

