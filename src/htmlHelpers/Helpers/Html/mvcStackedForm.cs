using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace sushi.Helpers.Html
{
    public class mvcStackedForm
    {
        #region Fields

        private bool disposed;
        private readonly HttpResponseBase httpResponse;

        #endregion

        #region CTOR

        public mvcStackedForm(HttpResponseBase httpResponse)
        {
            if (httpResponse == null)
            {
                throw new ArgumentNullException("httpResponse");
            }
            this.httpResponse = httpResponse;
        }

        #endregion

        #region Methods

        [SuppressMessage("Microsoft.Security", "CA2123:OverrideLinkDemandsShouldBeIdenticalToBase")]
        public void Dispose()
        {
            Dispose(true /* disposing */);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                this.disposed = true;
                this.httpResponse.Write("</div>");
            }
        }

        public void EndPanel()
        {
            Dispose(true);
        }

        #endregion
    }
}