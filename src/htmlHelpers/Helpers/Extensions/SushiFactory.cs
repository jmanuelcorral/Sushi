using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using Sushi.Helpers.BlockHelper;
using Sushi.Helpers.ButtonDropDownHelper;
using Sushi.Helpers.ButtonGroupHelper;
using Sushi.Helpers.ButtonHelper;
using Sushi.Helpers.Enums;
using Sushi.Helpers.FieldHelper;
using Sushi.Helpers.Gridhelper;
using Sushi.Helpers.LayoutHelper;
using Sushi.Helpers.LinkHelper;
using Sushi.Helpers.MenuHelper;
using Sushi.Helpers.PanelHelper;
using Sushi.Helpers.Resolvers;
using Sushi.Helpers.SideBarHelper;

namespace Sushi.Helpers.Extensions
{
   
   
   public class SushiFactory<TModel>
    {
       public ViewContext viewContext { get; private set; }

       public MvcHtmlString ScriptManager()
       {
           var stack = viewContext.HttpContext.Items[JSResolver.JSKey()] as Stack<string>;
           if (stack == null)
           {
               return MvcHtmlString.Empty;
           }

           var scriptTag = new TagBuilder("script");
           scriptTag.Attributes["type"] = "text/javascript";
           var sb = new StringBuilder();
           foreach (var script in stack)
           {
               sb.Append(script);
           }
           scriptTag.InnerHtml = sb.ToString();

           return new MvcHtmlString(scriptTag.ToString());
       }
        /// <summary>
        /// Helper that generates a new Button
        /// </summary>
        public Button Button()
        {
            var btn = new Button(viewContext);
            return btn;
        }

        public ButtonDropDown ButtonDropDown()
        {
            var btnDD = new ButtonDropDown(viewContext);
            return btnDD;
        }

        /// <summary>
        /// Helper that generates a new Panel
        /// </summary>
        /// <returns></returns>
        public Panel Panel()
        {
            var pn = new Panel(viewContext);
            return pn;
        }

         /// <summary>
        /// Helper that generates a new SideBar
        /// </summary>
        /// <param name="id">Id property of your html client control</param>
        /// <returns></returns>
        public SideBar SideBar()
        {
            var sd = new SideBar(viewContext);
            return sd;
        }
                
        /// <summary>
        /// Helper that generates a new Layout
        /// </summary>
        /// <returns></returns>
        public Layout Layout()
        {
            var ly = new Layout(viewContext);
            return ly;
        }

        /// <summary>
        /// Helper that generates a new Layout, It can be invoked by Using statement, Implements IDisposable Interface
        /// </summary>
        /// <param name="type"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public IDisposable BeginLayout(LayoutType type, GridSize size)
        {
            return BeginBlock(type, size);
        }

        /// <summary>
        /// Helper that generates a new Layout, It can be invoked by Using statement, Implements IDisposable Interface
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IDisposable BeginLayout(LayoutType type)
        {
            return BeginBlock(type);
        }

        /// <summary>
        /// Helper that generates a new Layout, It can be invoked by Using statement, Implements IDisposable Interface
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public IDisposable BeginLayout(GridSize size)
        {
            return BeginBlock(size);
        }
        /// <summary>
        /// Helper that generates a new html > div, using layout class and grid sizes, It can be invoked by Using statement, Implements IDisposable Interface
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IDisposable BeginBlock(LayoutType type)
        {
            var writer = this.viewContext.Writer;
            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass(Resolvers.LayoutManager.ResolveLayout(type));
            writer.Write(tag.ToString(TagRenderMode.StartTag));
            return new Block(writer);
        }
        /// <summary>
        /// Helper that generates a new html > div, using layout class and grid sizes, It can be invoked by Using statement, Implements IDisposable Interface
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public IDisposable BeginBlock(GridSize size)
        {
            var writer = this.viewContext.Writer;
            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass(Resolvers.GridResolver.ResolveSize(size));
            writer.Write(tag.ToString(TagRenderMode.StartTag));
            return new Block(writer);
        }

        /// <summary>
        /// Helper that generates a new html > div, using layout class and grid sizes, It can be invoked by Using statement, Implements IDisposable Interface
        /// </summary>
        /// <param name="type"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public IDisposable BeginBlock(LayoutType type, GridSize size)
        {
            var writer = this.viewContext.Writer;
            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass(Resolvers.LayoutManager.ResolveLayout(type));
            tag.AddCssClass(Resolvers.GridResolver.ResolveSize(size));
            writer.Write(tag.ToString(TagRenderMode.StartTag));
            return new Block(writer);
        }

        /// <summary>
        /// Helper that generates a new html > div, using layout class and grid sizes
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Layout Block(GridSize size)
        {
            var ly = new Layout(viewContext, size);
            return ly;
        }

        /// <summary>
        /// Helper that generates a Button Group
        /// </summary>
        /// <returns></returns>
        public ButtonGroup ButtonGroup()
        {
            var bg = new ButtonGroup(viewContext);
            return bg;
        }


        
        /// <summary>
        /// Helper that generates a Link 
        /// </summary>
        /// <returns></returns>
        public Link Link()
        {
            var mnu = new Link(this.viewContext);
            return mnu;
        }

        /// <summary>
        /// Html Helper that generates a form field
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Field Field<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, new ViewDataDictionary <TModel>());
            var fld = new Field(viewContext);
            if (modelMetadata.IsReadOnly)
            {
                //fld.setReadOnly();
            }
            fld.SetLabelValue(modelMetadata.PropertyName);
            fld.SetInputId(modelMetadata.DisplayName + "." + modelMetadata.PropertyName);
            fld.SetInputValue(modelMetadata.PropertyName);
            return fld;
        }

        /// <summary>
        /// Html Helper that generates a Html Table
        /// </summary>
        /// <returns></returns>
        public Grid<TProperty> Grid<TProperty>(Expression<Func<TModel, TProperty>> expression) where TProperty : IList
        {
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<TModel>(this.viewContext.ViewData));
            var modelMetadata2 = ModelMetadataProviders.Current.GetMetadataForType(null, modelMetadata.Model.GetType());
            var grd = new Grid<TProperty>(this.viewContext, modelMetadata);
            
            return grd;
        }

        /// <summary>
        /// Html Helper that generates a NavBar 
        /// </summary>
        /// <returns></returns>
        public Menu Menu()
        {
            var mnu = new Menu(this.viewContext);
            return mnu;
        }

       

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view"></param>
        public SushiFactory(ViewContext view)
        {
            viewContext = view;
        }
         
    }

    public class SushiFactory
    {
        public ViewContext viewContext { get; private set; }
        private const string ScriptsKey = "__scripts__";

        public MvcHtmlString ScriptManager()
        {
            var stack = viewContext.HttpContext.Items[ScriptsKey] as Stack<string>;
            if (stack == null)
            {
                return MvcHtmlString.Empty;
            }

            var scriptTag = new TagBuilder("script");
            scriptTag.Attributes["type"] = "text/javascript";
            var sb = new StringBuilder();
            foreach (var script in stack)
            {
                sb.AppendLine(script);
            }
            scriptTag.InnerHtml = sb.ToString();

            return new MvcHtmlString(scriptTag.ToString());
        }

        /// <summary>
        /// Helper that generates a new Button
        /// </summary>
        /// <returns><c>SushiButton</c> with the information of your control</returns>
        public Button Button()
        {
            var btn = new Button(viewContext);
            return btn;
        }

        public ButtonDropDown ButtonDropDown()
        {
            var btnDD = new ButtonDropDown(viewContext);
            return btnDD;
        }

        /// <summary>
        /// Helper that generates a new Panel
        /// </summary>
        /// <returns></returns>
        public Panel Panel()
        {
            var pn = new Panel(viewContext);
            return pn;
        }

        public ButtonGroup ButtonGroup()
        {
            var bg = new ButtonGroup(viewContext);
            return bg;
        }


        public Link Link()
        {
            var mnu = new Link(this.viewContext);
            return mnu;
        }
   
        /// <summary>
        /// Helper that generates a new SideBar
        /// </summary>
        /// <param name="id">Id property of your html client control</param>
        /// <returns></returns>
        public SideBar SideBar()
        {
            var sd = new SideBar(viewContext);
            return sd;
        }


        public Layout Layout()
        {
            var ly = new Layout(viewContext);
            return ly;
        }

        public IDisposable BeginLayout(LayoutType type, GridSize size)
        {
            return BeginBlock(type, size);
        }

        public IDisposable BeginLayout(LayoutType type)
        {
            return BeginBlock(type);
        }

        public IDisposable BeginLayout(GridSize size)
        {
            return BeginBlock(size);
        }

        public IDisposable BeginBlock(LayoutType type)
        {
            var writer = this.viewContext.Writer;
            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass(Resolvers.LayoutManager.ResolveLayout(type));
            writer.Write(tag.ToString(TagRenderMode.StartTag));
            return new Block(writer);
        }

        public IDisposable BeginBlock(GridSize size)
        {
            var writer = this.viewContext.Writer;
            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass(Resolvers.GridResolver.ResolveSize(size));
            writer.Write(tag.ToString(TagRenderMode.StartTag));
            return new Block(writer);
        }

        public IDisposable BeginBlock(LayoutType type, GridSize size)
        {
            var writer = this.viewContext.Writer;
            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass(Resolvers.LayoutManager.ResolveLayout(type));
            tag.AddCssClass(Resolvers.GridResolver.ResolveSize(size));
            writer.Write(tag.ToString(TagRenderMode.StartTag));
            return new Block(writer);
        }

        public Layout Block(GridSize size)
        {
            var ly = new Layout(viewContext, size);
            return ly;
        }

        public Menu Menu()
        {
            var mnu = new Menu(this.viewContext);
            return mnu;
        }
        /*
        public Link MenuItem()
        {
            var mnu = new Link(this.viewContext);
            return mnu;
        }
        */
        //public Grid<TProperty> Grid()
        //{
        //    var grd = new Grid(this.viewContext);
        //    return grd;
        //}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="helper"></param>
        public SushiFactory(ViewContext view )
        {
        this.viewContext = view;
        }
    }

}
