using System;
using System.Text;
using Sushi.Helpers.Javascript;

namespace Sushi.Helpers.Gridhelper
{
    public class GridOptions
    {
        private GridOptionsComponent Component;

        
        public GridOptions CanCacheViewedPages(Boolean Cache)
        {
            this.Component.cacheViewedPages = Cache;
            return this;
        }
        
        public GridOptions()
        {
            Component = new GridOptionsComponent();
        }

        public void ToJS(JSBuilder js)
        {
            if (this.Component.cacheViewedPages)
            {
                js.Add("bStateSave", "true");
            }
        } 
    }

    internal class GridOptionsComponent
    {
        internal Boolean cacheViewedPages { get; set; }
        public GridOptionsComponent()
        {
            this.cacheViewedPages = false;
        }
    }

}
