using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sushi.htmlHelpers.Test.Html
{

    public enum TextLoad
    {
        TestDefaultGrid10,
        TestDefaultGrid20,
        TestSecondGrid10,
        TestDefaultJS,
        TestSettedGridPagingControls,
        TestGridSettedPaginationControlsOff,
        TestSetted20RecordsPerPage,
        TestGridSettedPaginationOff,
        TestGridFilteringOn,
        TestGridFilteringOff,
        TestDefaultGridRemoteBinding,
        TestGridSettedRemoteBinding,
        TestGridHiddingOneColumn,
        TestGridHiddingTwoColumns,
        TestGridSortingOffOneColumn,
        TestGridSortingOffMultipleColumns,
        TestGridFilteringOffOneColumn,
        TestGridFilteringOffMultipleColumns,
        TestDefaultGrid100
    }

    public static class HtmlStringLoader
    {

        private static String Resolve(TextLoad loader)
        {
            switch (loader)
            {
                    case TextLoad.TestDefaultGrid10:
                        return "TestDefaultGrid10.txt";
                    case TextLoad.TestDefaultGrid20:
                        return "TestDefaultGrid20.txt";
                    case TextLoad.TestDefaultGrid100:
                        return "TestDefaultGrid100.txt";
                    case TextLoad.TestSecondGrid10:
                        return "TestSecondGrid10.txt";
                    case TextLoad.TestDefaultJS:
                        return "TestDefaultGridJS.txt";
                    case TextLoad.TestSettedGridPagingControls:
                        return "TestGridSettedPaginationControls.txt";
                    case TextLoad.TestGridSettedPaginationControlsOff:
                        return "TestGridSettedPaginationControlsOff.txt";
                    case TextLoad.TestSetted20RecordsPerPage:
                        return "TestGridSetted20RecordsPerPage.txt";
                    case TextLoad.TestGridSettedPaginationOff:
                        return "TestGridSettedPaginationOff.txt";
                    case TextLoad.TestGridFilteringOn:
                        return "TestGridFilteringOn.txt";
                    case TextLoad.TestGridFilteringOff:
                        return "TestGridFilteringOff.txt";
                    case TextLoad.TestDefaultGridRemoteBinding:
                        return "TestDefaultGridRemoteBinding.txt";
                    case TextLoad.TestGridSettedRemoteBinding:
                        return "TestGridSettedRemoteBinding.txt";
                    case TextLoad.TestGridHiddingOneColumn:
                        return "TestGridHiddingOneColumn.txt";
                    case TextLoad.TestGridHiddingTwoColumns:
                        return "TestGridHiddingTwoColumns.txt";
                    case TextLoad.TestGridSortingOffOneColumn:
                        return "TestGridSortingOffOneColumn.txt";
                    case TextLoad.TestGridSortingOffMultipleColumns:
                        return "TestGridSortingOffMultipleColumns.txt";
                    case TextLoad.TestGridFilteringOffOneColumn:
                        return "TestGridFilteringOffOneColumn.txt";
                    case TextLoad.TestGridFilteringOffMultipleColumns:
                        return "TestGridFilteringOffMultipleColumns.txt";
                    default:
                    return "";
            }
        }

        public static String GetHtmlStringResource(TextLoad loader)
        {
            return System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\src\\sushi.htmlHelpers.Test\\HtmlStrings\\" + Resolve(loader)).Replace("\t", "").Replace("\n", "").Replace("\r", "");
        }
    }
}
