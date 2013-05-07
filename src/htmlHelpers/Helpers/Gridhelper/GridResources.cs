using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Sushi.Helpers.Javascript;


namespace Sushi.Helpers.Gridhelper
{
    public class GridResources
    {
        public GridResources()
        {
            
        }

        public void ToJS(JSBuilder js)
        {
         /*
             "sLengthMenu": 'Display <select>' +
                           '<option value="10">10</option>' +
                           '<option value="20">20</option>' +
                           '<option value="50">50</option>' +
                           '<option value="100">100</option>' +
                           '<option value="-1">all</option>' +
                           '</select> ids'
           }
         */
            JSBuilder jsInternal = new JSBuilder();
            #region General
            jsInternal.Add("sProcessing", String.Format("\"{0}\"", Sushi.Resources.Resources.gridProcessing));
            jsInternal.Add("sZeroRecords", String.Format("\"{0}\"", Sushi.Resources.Resources.gridZeroRecords));
            jsInternal.Add("sInfo", String.Format("\"{0}\"", Sushi.Resources.Resources.gridInfo));
            jsInternal.Add("sInfoEmpty", String.Format("\"{0}\"", Sushi.Resources.Resources.gridInfoEmpty));
            jsInternal.Add("sInfoFiltered", String.Format("\"{0}\"", Sushi.Resources.Resources.gridInfoFiltered));
            jsInternal.Add("sInfoPostFix", String.Format("\"{0}\"", Sushi.Resources.Resources.gridInfoPostFix));
            jsInternal.Add("sSearch", String.Format("\"{0}\"", Sushi.Resources.Resources.gridSearch));
            jsInternal.Add("sUrl", String.Format("\"{0}\"", Sushi.Resources.Resources.gridUrl));
            jsInternal.Add("sLengthMenu", String.Format("\"{0}\"", Sushi.Resources.Resources.gridLengthMenu));
            #endregion
            
            #region pagination
            JSBuilder jsPagination = new JSBuilder();
            jsPagination.Add("sFirst", String.Format("\"{0}\"", Sushi.Resources.Resources.gridFirst));
            jsPagination.Add("sLast", String.Format("\"{0}\"", Sushi.Resources.Resources.gridLast));
            jsPagination.Add("sNext", String.Format("\"{0}\"", Sushi.Resources.Resources.gridNext));
            jsPagination.Add("sPrevious", String.Format("\"{0}\"", Sushi.Resources.Resources.gridPrevious));
            jsInternal.Add("oPaginate", jsPagination.ToLiteralJSObject(true));
            #endregion

            //jsInternal.Add("sLenghtMenu", String.Format("\"{0}\"", Sushi.Resources.Resources.gridLengthMenu));
            
            js.Add("oLanguage", jsInternal.ToLiteralJSObject(true));
        }
    }
}
