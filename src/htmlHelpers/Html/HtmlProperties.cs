using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Mvc;
using Sushi.Resolvers;

namespace Sushi.Html
{
    public class HtmlProperties
    {
        private ViewContext _viewContext;
        private Type _objectType;
        private String _id ;
        private String _value;
        private String _name;
        public String Id
        {
            get
            {
                //if (String.IsNullOrEmpty(_id))
                //    _id = HtmlResolver.GenerateHtmlValidId(this._viewContext, _objectType);
                return _id;
            }
            set { 
                _id = value;
                this.AddHtmlAttribute(Enums.HtmlAttributes.id, value);
            }
        }
        public String InnerHtml { get; set; }
        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
             this.AddHtmlAttribute(Enums.HtmlAttributes.name, value);
            } 
        }
        public String Value {
            get { return _value; } 
            set 
            { 
                _value = value;
                this.AddHtmlAttribute(Enums.HtmlAttributes.value, value);
            } 
        }

        public Dictionary<String, String> HtmlAttributes { get; private set; }
        private List<String> CssAttributes;

        public void AddHtmlAttribute(Enums.HtmlAttributes attribute, String attributeValue)
        {
            String attributeId = Resolvers.HtmlResolver.GenerateHtmlAttributeString(attribute);
            if (this.HtmlAttributes.ContainsKey(attributeId))
            {
                this.HtmlAttributes[attributeId] = attributeValue;
            }
            else
            {
                this.HtmlAttributes.Add(attributeId, attributeValue);    
            }
        }

        public String GetHtmlAttributeString()
        {
            String returnstring = "";
            foreach (var attribute in HtmlAttributes)
            {
                returnstring+= " " + attribute.Key + "=\"" + attribute.Value +"\"";
            }
            return returnstring;
        }

        public String GetCSSClassesString()
        {
            String returnstring = "";
            foreach (String cssclass in CssAttributes)
            {
                returnstring+= CssAttributes + " ";
            }
            return returnstring;
        }

        public void AddCssClass(String cssClass)
        {
            this.CssAttributes.Add(cssClass);
        }

        public HtmlProperties(ViewContext view, Type objType)
        {
            this._viewContext = view;
            this._objectType = objType;
            this.HtmlAttributes = new Dictionary<string, string>();
            this.CssAttributes = new List<string>();
        }

        public HtmlProperties(ViewContext view, Type objType, String id)
        {
            this._viewContext = view;
            this._objectType = objType;
            this.Id = id;
            this.HtmlAttributes = new Dictionary<string, string>();
            this.CssAttributes = new List<string>();
        }

        public HtmlProperties()
        {
            this._viewContext = null;
            this._objectType = null;
            this.HtmlAttributes = new Dictionary<string, string>();
            this.CssAttributes = new List<string>();
        }
    }
}
