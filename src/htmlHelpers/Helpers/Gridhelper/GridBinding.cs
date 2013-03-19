using System;
using Sushi.Helpers.Javascript;

namespace Sushi.Helpers.Gridhelper
{
    public class GridBinding
    {
        internal GridBindingComponent Component;

        public GridBinding Setup(String Action)
        {
            this.Component.Action = Action;
            return this;
        }

        public GridBinding isRemote(Boolean remote)
        {
            this.Component.IsRemote = remote;
            return this;
        }

        public GridBinding()
        {
            this.Component = new GridBindingComponent();
        }

        public void ToJS(JSBuilder js)
        {
           if (Component.IsRemote && !String.IsNullOrEmpty(Component.Action))
            { 
                //js.Add("bProcessing", "true");
                js.Add("bServerSide", "true");
                js.Add("sAjaxSource", this.Component.ActionToJSValue());
            }
        }
    }

    internal class GridBindingComponent
    {
        private String action;
        public String Action { 
           get { return action; } 
           set
           {
                if(!String.IsNullOrEmpty(value))
                {
                    this.action = value;
                    IsRemote = true;
                }
           }
        }
        public Boolean IsRemote { get; set; }
        internal String ActionToJSValue()
        {
            return String.Format("'{0}'", this.action);
        }

        public GridBindingComponent()
        {
            action = "";
            IsRemote = false;
        }
    }
}
