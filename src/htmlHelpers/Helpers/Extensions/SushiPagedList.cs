using System.Collections.Generic;
using System.Linq;

namespace Sushi.Helpers.Extensions
{
    public class SushiPagedList<T> : List<T>, ISushiPagedList
    {
        public SushiPagedList(IQueryable<T> source, int index, int pageSize)
        {
            this.TotalCount = source.Count();
            this.PageSize = pageSize;
            this.PageIndex = index;
            this.AddRange(source.Skip(index * pageSize).Take(pageSize).ToList());
        }    
        
        public SushiPagedList(List<T> source, int index, int pageSize)
        {
            this.TotalCount = source.Count();
            this.PageSize = pageSize;
            this.PageIndex = index;
            this.AddRange(source.Skip(index * pageSize).Take(pageSize).ToList());
        }
    
        public int TotalCount      
        { 
            get; set; 
        }
        
        public int PageIndex       
        { 
            get; set; 
        }
        
        public int PageSize 
        { 
            get; set; 
        }

        public bool IsPreviousPage 
        { 
            get 
            {
                return (PageIndex > 0);
            }
        }
        
        public bool IsNextPage 
        { 
            get
            {
                return (PageIndex * PageSize) <=TotalCount;
            } 
        }        
    }
}
