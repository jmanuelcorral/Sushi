using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using sushi.htmlHelpers.Test.Model;

namespace sushi.htmlHelpers.Test
{
    public static class FakeHtmlHelper
    {
        public static string ResponseText { get; set; }
        public static Hashtable Elements { get; set; }
        public static ViewDataDictionary vDD { get; set; }
        
        
        /// <summary>
        /// Creates a Fake HtmlHelper for testing purposes
        /// </summary>
        /// <param name="vd"></param>
        /// <returns></returns>
        public static HtmlHelper CreateFakeHtmlHelper(ViewDataDictionary vd)
        {
            //Create mockViewContext
            Elements = new Hashtable();
            var mockViewContext = new Mock<ViewContext>(
                new ControllerContext(
                    new Mock<HttpContextBase>().Object,
                    new RouteData(),
                    new Mock<ControllerBase>().Object),
                new Mock<IView>().Object,
                vd,
                new TempDataDictionary(),
                new Mock<TextWriter>().Object);
            //We must initialize Writer Object 
            mockViewContext.Setup(r => r.Writer.Write(It.IsAny<string>())).Callback((string s) => ResponseText += s);
            mockViewContext.Setup(r => r.HttpContext.Items).Returns(Elements);
            
            //DataContainer (used for StronglyTyped purposes)
            var mockViewDataContainer = new Mock<IViewDataContainer>();
            mockViewDataContainer.Setup(v => v.ViewData)
                .Returns(vd);
            return new HtmlHelper(mockViewContext.Object,
                                  mockViewDataContainer.Object);
        }

        public static ViewDataDictionary CreateFakeViewDataDictionary()
        {
            var dict = new ViewDataDictionary(); 
            dict.Add("test", "test");
            return dict;
        }

        public static void CreateStronglyTypedFakeViewDataDictionary(Person person)
        {
            vDD = new ViewDataDictionary<Person>(person);
        }

        public static HtmlHelper<Person> CreateStronglyTypedHtmlHelper()
        {
            CreateStronglyTypedFakeViewDataDictionary(new Person());
            //Create mockViewContext
            Elements = new Hashtable();
            var mockViewContext = new Mock<ViewContext>(
                new ControllerContext(
                    new Mock<HttpContextBase>().Object,
                    new RouteData(),
                    new Mock<ControllerBase>().Object),
                new Mock<IView>().Object,
                vDD,
                new TempDataDictionary(),
                new Mock<TextWriter>().Object);
            //We must initialize Writer Object 
            mockViewContext.Setup(r => r.Writer.Write(It.IsAny<string>())).Callback((string s) => ResponseText += s);
            mockViewContext.Setup(r => r.HttpContext.Items).Returns(Elements);


            //DataContainer (used for StronglyTyped purposes)
            var mockViewDataContainer = new Mock<IViewDataContainer>();
            mockViewDataContainer.Setup(r => r.ViewData).Returns(vDD);
            mockViewContext.Setup(r => r.ViewData).Returns(vDD);

            return new HtmlHelper<Person>(mockViewContext.Object,
                                  mockViewDataContainer.Object);
        }
        
    }

  
}
