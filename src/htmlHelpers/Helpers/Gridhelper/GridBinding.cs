using System;
using Sushi.Helpers.Javascript;

namespace Sushi.Helpers.Gridhelper
{
    public class GridBinding
    {
        private GridBindingComponent Component;

        public GridBinding Setup(String Action)
        {
            this.Component.Action = Action;
            return this;
        }

        public GridBinding()
        {
            this.Component = new GridBindingComponent();
        }

        public void ToJS(JSBuilder js)
        {
            /*
              "bProcessing": true,
		      "sAjaxSource": '../examples_support/json_source.txt'
            */
            js.Add("bProcessing", "true");
            js.Add("bServerSide", "true");
            js.Add("sAjaxSource", this.Component.ActionToJSValue());
        }
    }

    internal class GridBindingComponent
    {
        public String Action { get; set; }
        internal String ActionToJSValue()
        {
            return String.Format("'{0}'", this.Action);
        }
    }
}
