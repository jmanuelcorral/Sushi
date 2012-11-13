using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Sushi.BlockHelper;
using Sushi.ButtonGroupHelper;
using Sushi.ButtonHelper;
using Sushi.DropDownHelper;
using Sushi.Enums;
using Sushi.FieldHelper;
using Sushi.Gridhelper;
using Sushi.LayoutHelper;
using Sushi.LinkHelper;
using Sushi.MenuHelper;
using Sushi.NavigationHelper;
using Sushi.PanelHelper;
using Sushi.SideBarHelper;

namespace Sushi.Extensions
{
    public class SushiFactory<TModel>
    {
        public ViewContext viewContext { get; private set; }

        /// <summary>
        /// Helper that generates a new Button
        /// </summary>
        public Button Button()
        {
            var btn = new Button(viewContext);
            return btn;
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

        public Navigation Navigation()
        {
            var mnu = new Navigation(this.viewContext);
            return mnu;
        }

        //public Brand Brand()
        //{
        //    var brand = new Brand(this.viewContext);
        //    return brand;
        //}

        public NavigationItem NavigationItem()
        {
            var mnu = new NavigationItem(this.viewContext);
            return mnu;
        }

        public NavigationItemHeader NavigationItemHeader()
        {
            var mnu = new NavigationItemHeader(this.viewContext);
            return mnu;
        }

        public NavigationDropDown NavigationDropDown()
        {
            var mnu = new NavigationDropDown(viewContext);
            return mnu;
        }

        public DropDown DropDown()
        {
            var ddp = new DropDown(viewContext);
            return ddp;
        }

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

        public Menu Menu()
        {
            var mnu = new Menu(this.viewContext);
            return mnu;
        }

        public SearchBox MenuSearchBoxItem()
        {
            var mnu = new SearchBox(this.viewContext);
            return mnu;
        }
       
        public Grid Grid()
        {
            var grd = new Grid(this.viewContext);
            return grd;
        }

      public SushiFactory(ViewContext view)
        {
          viewContext = view;
        }
         
    }

    public class SushiFactory
    {
        public ViewContext viewContext { get; private set; }

        /// <summary>
        /// Helper that generates a new Button
        /// </summary>
        /// <returns><c>SushiButton</c> with the information of your control</returns>
        public Button Button()
        {
            var btn = new Button(viewContext);
            return btn;
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

        
        public SearchBox MenuSearchBoxItem()
        {
            var mnu = new SearchBox(this.viewContext);
            return mnu;
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

        public Navigation Navigation()
        {
            var mnu = new Navigation(this.viewContext);
            return mnu;
        }

        //public Brand Brand()
        //{
        //    var brand = new Brand(this.viewContext);
        //    return brand;
        //}

        public NavigationItem NavigationItem()
        {
            var mnu = new NavigationItem(this.viewContext);
            return mnu;
        }

        public NavigationItemHeader NavigationItemHeader()
        {
            var mnu = new NavigationItemHeader(this.viewContext);
            return mnu;
        }

        public NavigationDropDown NavigationDropDown()
        {
            var mnu = new NavigationDropDown(viewContext);
            return mnu;
        }

        public DropDown DropDown()
        {
            var ddp = new DropDown(viewContext);
            return ddp;
        }

        /// <summary>
        /// Helper that generates a new SideBar
        /// </summary>
        /// <param name="id">Id property of your html client control</param>
        /// <returns></returns>
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

        public Link MenuItem()
        {
            var mnu = new Link(this.viewContext);
            return mnu;
        }

        public Grid Grid()
        {
            var grd = new Grid(this.viewContext);
            return grd;
        }

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
