using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Sushi.Helpers.Extensions;
using sushi.htmlHelpers.Test.Html;
using sushi.htmlHelpers.Test.Model;

namespace sushi.htmlHelpers.Test.Helpers
{
    [TestFixture]
    public class GridTest
    {
        [Test]
        public void TestDefault()
        {
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(new List<Person>());
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelperWithCollection();
            var comparer = SushiExtension.Sushi(htmlHelper).Grid(x => x).ToHtmlString();
            Assert.AreEqual(comparer, "<table class=\"span1\" id=\"Grid1\"><thead><tr></tr></thead><tbody></tbody></table>");
        }

        [Test]
        public void TestDefaultStronglyTyped10RecordsModel()
        {
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(ModelFactories.GetPeople10Collection());
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelperWithCollection();
            var resultObtained = SushiExtension.Sushi(htmlHelper).Grid(x => x).Bind().ToHtmlString();
            var resultExpected = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultGrid10);
            Assert.AreEqual(resultExpected, resultObtained);
        }

        [Test]
        public void TestDefault20RecordsModel()
        {
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(ModelFactories.GetPeople20Collection());
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelperWithCollection();
            var resultObtained = SushiExtension.Sushi(htmlHelper).Grid(x => x).Bind().ToHtmlString();
            var resultExpected = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultGrid20);
            Assert.AreEqual(resultExpected, resultObtained);
        }

        [Test]
        public void TestJavascriptIsLoaded()
        {
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(ModelFactories.GetPeople20Collection());
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelperWithCollection();
            var execution = SushiExtension.Sushi(htmlHelper).Grid(x => x)
                    .Bind()
                    .ToHtmlString();
            var resultObtained = SushiExtension.Sushi(htmlHelper).ScriptManager().ToString();
            var resultExpected = "<script type=\"text/javascript\">$('Grid1').dataTable();</script>";
            Assert.AreEqual(resultExpected, resultObtained.ToString());
        }
    }
}
