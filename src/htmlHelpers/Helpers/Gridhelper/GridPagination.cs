using System;
using System.Text;
using Sushi.Helpers.Javascript;

namespace Sushi.Helpers.Gridhelper
{
    public class GridPagination
    {
        private GridPaginationComponent Component;

        public GridPagination Paginable(Boolean value)
        {
            this.Component.IsPaginable = value;
            return this;
        }

       public GridPagination DisplayPaginationOptions (Boolean value)
        {
            this.Component.CanDisplayPaginationOptions = value;
            return this;
        }

        public GridPagination RowsPerPage (Int32 value)
        {
            this.Component.RowsPerPage = value;
            return this;
        }

        public GridPagination(GridPagination grd)
        {
            this.Component = new GridPaginationComponent();
            this.Component.CanDisplayPaginationOptions = grd.Component.CanDisplayPaginationOptions;
            this.Component.RowsPerPage = grd.Component.RowsPerPage;
        }

        public GridPagination()
        {
            this.Component = new GridPaginationComponent();
            this.Component.IsPaginable = true;
            this.Component.CanDisplayPaginationOptions = false;
            this.Component.RowsPerPage = 10;
        }

        public void ToJS(JSBuilder js)
        {
            #region pagination
            if (this.Component.IsPaginable)
            {
                js.Add("bPaginate", "true");
                if (this.Component.CanDisplayPaginationOptions)
                {
                    js.Add("bLengthChange", "true");
                }
                else
                {
                    js.Add("bLengthChange", "false");
                }
                if (this.Component.RowsPerPage != 10)
                {
                    js.Add("iDisplayLength", this.Component.RowsPerPage.ToString());
                }
            }
            else
            {
                js.Add("bPaginate", "false");
            }
            #endregion
        } 
    }

    internal class GridPaginationComponent
    {
        public Boolean IsPaginable { get; set; }
        public Boolean CanDisplayPaginationOptions { get; set; }
        public int RowsPerPage { get; set; }
    }
}
