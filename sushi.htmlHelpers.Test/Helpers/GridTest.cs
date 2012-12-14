using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Sushi.Extensions;
using sushi.htmlHelpers.Test.Model;

namespace sushi.htmlHelpers.Test.Helpers
{
    [TestFixture]
    public class GridTest
    {
        [Test]
        public void TestDefault()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var comparer = SushiExtension.Sushi(htmlHelper).Grid().ToHtmlString();
            Assert.AreEqual(comparer, "<table class=\"span1\"><thead><tr></tr></thead><tbody></tbody></table>\">");
        }

        [Test]
        public void TestDefaultStronglyTyped()
        {
            var ListModel = ModelFactories.GetPeople10Collection();
            var htmlHelper = FakeHtmlHelper.CreateHtmlHelper(ListModel);
            htmlHelper.ViewData.Model = ListModel; //Inicializamos el Modelo
            var comparer = SushiExtension.Sushi(htmlHelper).Grid(x => x).ToHtmlString();
            Assert.AreEqual(comparer, "<table class=\"span1\"><thead><tr></tr></thead><tbody></tbody></table>\">");
        }

    }
}
