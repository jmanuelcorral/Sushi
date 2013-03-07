using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Sushi.Helpers.Extensions;

namespace sushi.htmlHelpers.Test.Helpers
{
    [TestFixture]
    public class ButtonDropDownTest
    {
        [Test]
        public void TestDefault()
        {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
            var obtained = SushiExtension.Sushi(htmlHelper).ButtonDropDown().ToString();
            var expected = "";
            Assert.AreEqual(expected, obtained);
        }

    }
}
