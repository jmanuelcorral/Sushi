using System;
using System.Collections.Generic;
using System.Text;
using Sushi.Helpers.Javascript;

namespace Sushi.Helpers.Gridhelper
{
    public class GridColumnOptions
    {
        private GridColumnCollection component;

        public GridColumnOptions()
        {
            this.component = new GridColumnCollection();
        }

        public GridColumnOptions ColumnSortable(int index, bool sorting)
        {
            var col = component.SearchByIndex(index);
            col.sorting = sorting;
            return this;
        }

        public GridColumnOptions ColumnFilterable(int index, bool filtering)
        {
            var col = component.SearchByIndex(index);
            col.filtering = filtering;
            return this;
        }

        public GridColumnOptions ColumnVisible(int index, bool visible)
        {
            var col = component.SearchByIndex(index);
            col.visible = visible;
            return this;
        }


        public void ToJS(JSBuilder js)
        {
            if (this.component.collection.Count > 0)
            {
                JSBuilder Maindeclaration = new JSBuilder();
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var element in this.component.collection)
                {
                    //Creo un JSBuilderElement para declarar un Literal Object, y luego realizaré el toString
                    var jsBuilderElement = new JSBuilder();
                    if (!element.visible)
                    {
                        jsBuilderElement.Add("bVisible", "false");
                    }
                    string aTargets = String.Format("[{0}]", element.Index);
                    jsBuilderElement.Add("aTargets", aTargets);
                    stringBuilder.AppendFormat("{0},", jsBuilderElement.ToLiteralJSObject(true));
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);

                String columnDefs = String.Format("[{0}]", stringBuilder.ToString());
                js.Add("aoColumnDefs", columnDefs);
            }
        }

    }

    internal class GridColumnCollection
    {
        internal List<GridColumnComponent> collection;
        
        public GridColumnComponent SearchByIndex(int index)
        {
           
            foreach (var gridColumnComponent in collection)
            {
                if (gridColumnComponent.Index == index) { return gridColumnComponent; }
            }
            GridColumnComponent col = new GridColumnComponent() {Index = index};
            this.collection.Add(col);
            return col;
        }

        public GridColumnCollection()
        {
            this.collection = new List<GridColumnComponent>();
        }


    }

    internal class GridColumnComponent
    {
        public String th { get; set; }
        public int Index { get; set; }
        public Boolean sorting { get; set; }
        public Boolean filtering { get; set; }
        public Boolean visible { get; set; }


        public GridColumnComponent()
        {
          
        }
    }
}
