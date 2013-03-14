using System;
using System.Text;
using Sushi.Helpers.Javascript;

namespace Sushi.Helpers.Gridhelper
{
    public class GridSearch
    {
       private GridSearchComponent Component;

       public GridSearch SearchActive(Boolean value)
       {
           this.Component.ActivateSearch = value;
           return this;
       }

        public GridSearch(GridSearch grd)
        {
           this.Component = new GridSearchComponent();
           this.Component.ActivateSearch = grd.Component.ActivateSearch;
        }

        public GridSearch()
        {
            this.Component = new GridSearchComponent();
            this.Component.ActivateSearch = false;
        }

        public void ToJS(JSBuilder JS)
        {
            if (this.Component.ActivateSearch)
            {
                JS.Add("bFilter", "true");
            }
            else
            {
                JS.Add("bFilter", "false");
            }
        } 
    }

    internal class GridSearchComponent
    {
        public Boolean ActivateSearch { get; set; }
    }
}
