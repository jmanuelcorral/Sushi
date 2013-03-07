using System;
using System.Text;

namespace Sushi.Helpers.Gridhelper
{
    public class GridOptions
    {
        private GridOptionsComponent Component;

        public GridOptions Paginable(Boolean value)
        {
            this.Component.isPaginable = value;
            return this;
        }

        public GridOptions Sortable(Boolean value)
        {
            this.Component.isSortable = value;
            return this;
        }

        public GridOptions DisplaySearch (Boolean value)
        {
            this.Component.canDisplaySearch = value;
            return this;
        }

        public GridOptions DisplayPaginationOptions (Boolean value)
        {
            this.Component.canDisplayPaginationOptions = value;
            return this;
        }

        public GridOptions RowsPerPage (Int32 value)
        {
            this.Component.rowsPerPage = value;
            return this;
        }

        public GridOptions(GridOptions grd)
        {
            this.Component = new GridOptionsComponent();
            this.Component.isPaginable = grd.Component.isPaginable;
            this.Component.isSortable = grd.Component.isSortable;
            this.Component.canDisplaySearch = grd.Component.canDisplaySearch;
            this.Component.canDisplayPaginationOptions = grd.Component.canDisplayPaginationOptions;
            this.Component.rowsPerPage = grd.Component.rowsPerPage;
        }
        
        public GridOptions()
        {
            this.Component = new GridOptionsComponent();
            this.Component.isPaginable = true;
            this.Component.isSortable = true;
            this.Component.canDisplaySearch = true;
            this.Component.canDisplayPaginationOptions = false;
            this.Component.rowsPerPage = 10;
        }

        public String ToJSOptions()
        {
            StringBuilder resultjs = new StringBuilder();
            #region pagination
            if (this.Component.isPaginable)
            {
                resultjs.Append("\"bPaginate\": true,");
                if (this.Component.canDisplayPaginationOptions)
                {
                    resultjs.Append("\"bLengthChange\": true");
                    if (this.Component.rowsPerPage != 0)
                    {
                        resultjs.Append(",");
                    }
                }
                else
                {
                    resultjs.Append("\"bLengthChange\": false");
                    if (this.Component.rowsPerPage != 10)
                    {
                        //this.Component.rowsPerPage = 10;
                        resultjs.Append(",");
                    }
                }
                if (this.Component.rowsPerPage != 10)
                {
                    resultjs.Append("\"iDisplayLength\": ");
                    resultjs.Append(this.Component.rowsPerPage);
                }
            }
            else
            {
                resultjs.Append("\"bPaginate\": false,");
                resultjs.Append("\"bLengthChange\": false");
            }
            #endregion

            return resultjs.ToString();
        } 
    }

    internal class GridOptionsComponent
    {
        public Boolean isPaginable { get; set; }
        public Boolean isSortable { get; set; }
        public Boolean canDisplaySearch { get; set; }
        public Boolean canDisplayPaginationOptions { get; set; }
        public int rowsPerPage { get; set; }
    }

}
