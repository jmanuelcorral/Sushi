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
            var expected = "<table id=\"Grid1\"><thead><tr></tr></thead><tbody></tbody></table>";
            Assert.AreEqual(expected, comparer );
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
            var resultExpected = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultJS);
            Assert.AreEqual(resultExpected, resultObtained.ToString());
        }

        #region Pagination Testing
        [Test]
        public void TestSetGridDisplayPaginationOptionsFalse()
        {
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(ModelFactories.GetPeople20Collection());
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelperWithCollection();
            var execution = SushiExtension.Sushi(htmlHelper).Grid(x => x)
                    .Bind()
                    .Pagination(pagination => pagination.DisplayPaginationOptions(false))
                    .ToHtmlString();
            var expectedtable = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultGrid20);
            Assert.AreEqual(expectedtable, execution);
            var resultObtained = SushiExtension.Sushi(htmlHelper).ScriptManager().ToString();
            var resultExpected = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultJS);
            Assert.AreEqual(resultExpected, resultObtained);
        }

        [Test]
        public void TestSetGridDisplayPaginationOptionsTrue()
        {
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(ModelFactories.GetPeople20Collection());
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelperWithCollection();
            var execution = SushiExtension.Sushi(htmlHelper).Grid(x => x)
                    .Bind()
                    .Pagination(pagination => pagination.DisplayPaginationOptions(true))
                    .ToHtmlString();
            var expectedtable = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultGrid20);
            Assert.AreEqual(expectedtable, execution);
            var resultObtained = SushiExtension.Sushi(htmlHelper).ScriptManager().ToString();
            var resultExpected = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestSettedGridPagingControls);
            Assert.AreEqual(resultExpected, resultObtained);
        }

        [Test]
        public void TestSetGridPagination20ResultsPerPage()
        {
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(ModelFactories.GetPeople20Collection());
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelperWithCollection();
            var execution = SushiExtension.Sushi(htmlHelper).Grid(x => x)
                    .Bind()
                    .Pagination(pagination => pagination.RowsPerPage(20))
                    .ToHtmlString();
            var expectedtable = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultGrid20);
            Assert.AreEqual(expectedtable, execution);
            var resultObtained = SushiExtension.Sushi(htmlHelper).ScriptManager().ToString();
            var resultExpected = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestSetted20RecordsPerPage);
            Assert.AreEqual(resultExpected, resultObtained);
        }

        [Test]
        public void TestSetGridPaginationOff()
        {
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(ModelFactories.GetPeople20Collection());
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelperWithCollection();
            var execution = SushiExtension.Sushi(htmlHelper).Grid(x => x)
                    .Bind()
                    .Pagination(pagination => pagination.Paginable(false))
                    .ToHtmlString();
            var expectedtable = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultGrid20);
            Assert.AreEqual(expectedtable, execution);
            var resultObtained = SushiExtension.Sushi(htmlHelper).ScriptManager().ToString();
            var resultExpected = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestGridSettedPaginationOff);
            Assert.AreEqual(resultExpected, resultObtained);
        }
        #endregion

        #region Filtering
        [Test]
        public void TestSetGridFilteringOn()
        {
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(ModelFactories.GetPeople20Collection());
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelperWithCollection();
            var execution = SushiExtension.Sushi(htmlHelper).Grid(x => x)
                    .Bind()
                    .Search(search => search.SearchActive(true))
                    .ToHtmlString();
            var expectedtable = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultGrid20);
            Assert.AreEqual(expectedtable, execution);
            var resultObtained = SushiExtension.Sushi(htmlHelper).ScriptManager().ToString();
            var resultExpected = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestGridFilteringOn);
            Assert.AreEqual(resultExpected, resultObtained);
        }

        [Test]
        public void TestSetGridFilteringOff()
        {
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(ModelFactories.GetPeople20Collection());
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelperWithCollection();
            var execution = SushiExtension.Sushi(htmlHelper).Grid(x => x)
                    .Bind()
                    .Search(search => search.SearchActive(false))
                    .ToHtmlString();
            var expectedtable = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultGrid20);
            Assert.AreEqual(expectedtable, execution);
            var resultObtained = SushiExtension.Sushi(htmlHelper).ScriptManager().ToString();
            var resultExpected = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestGridFilteringOff);
            Assert.AreEqual(resultExpected, resultObtained);
        }
        #endregion

        #region Binding Remote
        [Test]
        public void TestSetGridRemoteBinding()
        {
            FakeHtmlHelper.CreateStronglyTypedFakeViewDataDictionary(ModelFactories.GetPeople20Collection());
            var htmlHelper = FakeHtmlHelper.CreateStronglyTypedHtmlHelperWithCollection();
            var execution = SushiExtension.Sushi(htmlHelper).Grid(x => x)
                    .Bind()
                    .Binding(binding => binding.Setup("/StringAction"))
                    .ToHtmlString();
            var expectedtable = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestDefaultGridRemoteBinding);
            Assert.AreEqual(expectedtable, execution);
            var resultObtained = SushiExtension.Sushi(htmlHelper).ScriptManager().ToString();
            var resultExpected = HtmlStringLoader.GetHtmlStringResource(TextLoad.TestGridSettedRemoteBinding);
            Assert.AreEqual(resultExpected, resultObtained);
        }
        #endregion

    }
}
