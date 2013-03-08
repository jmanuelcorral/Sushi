using System;
using System.Text;
using Sushi.Helpers.Javascript;

namespace Sushi.Helpers.Gridhelper
{
    public class GridOptions
    {
        private GridOptionsComponent Component;

        
        public GridOptions(GridOptions grd)
        {
        
        }
        
        public GridOptions()
        {
        }

        public void ToJS(JSBuilder js)
        {
            
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
