using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Sushi.Extensions;

namespace sushi.htmlHelpers.Test.Helpers
{
    [TestFixture]
    public class ButtonDropDownTest
    {
        [Test]
        public void TestDefault()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            //var comparer = SushiExtension.Sushi(htmlHelper).ButtonDropDown().ToString();
            Assert.Inconclusive("Refactor");
            //Assert.AreEqual(comparer, "<div class=\"btn-group\"></div>");
        }

    }
}
