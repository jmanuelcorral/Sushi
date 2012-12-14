using System.Web.Mvc;
using NUnit.Framework;
using Sushi.Extensions;

namespace sushi.htmlHelpers.Test.Helpers
{
    [TestFixture]
    public class DropDownTest
    {
       [Test]
       public void TestDefault()
       {
            HtmlHelper htmlHelper = FakeHtmlHelper.CreateFakeHtmlHelper(FakeHtmlHelper.CreateFakeViewDataDictionary());
           // var comparer = SushiExtension.Sushi(htmlHelper).DropDown().ToString();
           Assert.Inconclusive("Refactoring");
            //Assert.AreEqual(comparer, "<ul class=\"dropdown-menu\"></ul>");
       }
       
    }
}