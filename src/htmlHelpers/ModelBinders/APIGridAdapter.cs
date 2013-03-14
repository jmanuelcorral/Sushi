using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web.Http;
using System.Linq.Expressions;
using System.Web;

namespace Sushi.ModelBinders
{
    public class APIGridAdapter<T>
    {

        #region constants
        /*
        * int: iDisplayStart - Display start point
        * int: iDisplayLength - Number of records to display
        * string: string: sSearch - Global search field
        * boolean: bEscapeRegex - Global search is regex or not
        * int: iColumns - Number of columns being displayed (useful for getting individual column search info)
        * string: sSortable_(int) - Indicator for if a column is flagged as sortable or not on the client-side
        * string: sSearchable_(int) - Indicator for if a column is flagged as searchable or not on the client-side
        * string: sSearch_(int) - Individual column filter
        * boolean: bEscapeRegex_(int) - Individual column filter is regex or not
        * int: iSortingCols - Number of columns to sort on
        * int: iSortCol_(int) - Column being sorted on (you will need to decode this number for your database)
        * string: sSortDir_(int) - Direction to be sorted - "desc" or "asc". Note that the prefix for this variable is wrong in 1.5.x, but left for backward compatibility)
        * string: sEcho - Information for DataTables to use for rendering
         */

        private const string INDIVIDUAL_SEARCH_KEY_PREFIX = "sSearch_";
        private const string INDIVIDUAL_SORT_KEY_PREFIX = "iSortCol_";
        private const string INDIVIDUAL_SORT_DIRECTION_KEY_PREFIX = "sSortDir_";
        private const string DISPLAY_START = "iDisplayStart";
        private const string DISPLAY_LENGTH = "iDisplayLength";
        private const string ECHO = "sEcho";
        private const string ASCENDING_SORT = "asc";
    #endregion
        
        private IQueryable<T> _queriable;
        private readonly Uri _requestURI;
        private readonly Dictionary<String, String> _keys;
        private readonly Type _type;
        private readonly PropertyInfo[] _properties;


        public APIGridAdapter(Uri requestUri, IQueryable<T> queriable)
        {
            _queriable = queriable;
            _requestURI = requestUri;
            _keys = Utilities.UriParametersToDictionary(requestUri);
            _type = typeof(T);
            _properties = _type.GetProperties();
        }

       /// <summary>
        /// Parses the <see cref="HttpRequestBase"/> parameter values for the accepted 
        /// DataTable request values
        /// </summary>
        /// <returns>Formated output for DataTables, which should be serialized to JSON</returns>
        /// <example>
        ///     In an ASP.NET MVC from a controller, you can call the Json method and return this result.
        ///     
        ///     public ActionResult List()
        ///     {
        ///         // change the following line per your data configuration
        ///         IQueriable<User> users = datastore.Linq();
        ///         
        ///         if (Request["sEcho"] != null) // always test to see if the request is from DataTables
        ///         {
        ///             var parser = new DataTableParser<User>(Request, users);
        ///             return Json(parser.Parse());
        ///         }
        ///         return Json(_itemController.CachedValue);
        ///     }
        ///     
        ///     If you're not using MVC, you can create a web service and write the JSON output as such:
        ///     
        ///     using System.Web.Script.Serialization;
        ///     public class MyWebservice : System.Web.Services.WebService
        ///     {
        ///         public string MyMethod()
        ///         {
        ///             // change the following line per your data configuration
        ///             IQueriable<User> users = datastore.Linq();
        ///             
        ///             response.ContentType = "application/json";
        ///             
        ///             JavaScriptSerializer serializer = new JavaScriptSerializer();
        ///             var parser = new DataTableParser<User>(Request, users);
        ///             return new JavaScriptSerializer().Serialize(parser.Parse());
        ///         }
        ///     }
        /// </example>
       public GridResponse Process()
        {
            var list = new GridResponse();

            // import property names
            list.Import(_properties.Select(x => x.Name).ToArray());

            // parse the echo property (must be returned as int to prevent XSS-attack)
            list.sEcho = int.Parse(_keys[ECHO]);

            // count the record BEFORE filtering
            list.iTotalRecords = _queriable.Count();

            // apply the sort, if there is one
            ApplySort();

            // parse the paging values
            int skip = 0, take = 10;
            int.TryParse(_keys[DISPLAY_START], out skip);
            int.TryParse(_keys[DISPLAY_LENGTH], out take);

            // setup the data with individual property search, all fields search,
            // paging, and property list selection
            list.aaData = _queriable.Where(ApplyGenericSearch)
                                    .Where(IndividualPropertySearch)
                                    .Skip(skip)
                                    .Take(take)
                                    .Select(SelectProperties)
                                    .ToList();

            // total records that are displayed
            list.iTotalDisplayRecords = list.aaData.Count;

            return list;
        }

        private void ApplySort()
        {
            // enumerate the keys for any sortations
            foreach (string key in _keys.Keys.Where(x => x.StartsWith(INDIVIDUAL_SORT_KEY_PREFIX)))
            {
                // column number to sort (same as the array)
                int sortcolumn = int.Parse(_keys[key]);

                // ignore malformatted values
                if (sortcolumn < 0 || sortcolumn >= _properties.Length)
                    break;

                // get the direction of the sort
                string sortdir = _keys[INDIVIDUAL_SORT_DIRECTION_KEY_PREFIX + key.Replace(INDIVIDUAL_SORT_KEY_PREFIX, string.Empty)];

                // form the sortation per property via a property expression
                var paramExpr = Expression.Parameter(typeof(T), "val");
                var typeExpr = Expression.Property(paramExpr, _properties[sortcolumn]).Type;
                switch (typeExpr.ToString())
                {
                    case "System.Int32":
                        var propertyExprInt = Expression.Lambda<Func<T, Int32>>(Expression.Property(paramExpr, _properties[sortcolumn]), paramExpr);
                        // apply the sort (default is ascending if not specified)
                        if (string.IsNullOrEmpty(sortdir) || sortdir.Equals(ASCENDING_SORT, StringComparison.OrdinalIgnoreCase))
                        {
                            _queriable = _queriable.OrderBy(propertyExprInt);
                        }
                        else { _queriable = _queriable.OrderByDescending(propertyExprInt); }
                        break;
                    case "System.DateTime":
                        var propertyExprDate = Expression.Lambda<Func<T, DateTime>>(Expression.Property(paramExpr, _properties[sortcolumn]), paramExpr);
                        // apply the sort (default is ascending if not specified)
                        if (string.IsNullOrEmpty(sortdir) || sortdir.Equals(ASCENDING_SORT, StringComparison.OrdinalIgnoreCase))
                        {
                            _queriable = _queriable.OrderBy(propertyExprDate);
                        }
                        else { _queriable = _queriable.OrderByDescending(propertyExprDate); }
                        break;
                    case "System.String":
                        var propertyExpr = Expression.Lambda<Func<T, String>>(Expression.Property(paramExpr, _properties[sortcolumn]), paramExpr);
                        // apply the sort (default is ascending if not specified)
                        if (string.IsNullOrEmpty(sortdir) || sortdir.Equals(ASCENDING_SORT, StringComparison.OrdinalIgnoreCase))
                        {
                            _queriable = _queriable.OrderBy(propertyExpr);
                        }
                        else { _queriable = _queriable.OrderByDescending(propertyExpr); }
                        break;
                        /*
                    case default:
                        var propertyExpr = Expression.Lambda<Func<T, object>>(Expression.Property(paramExpr, _properties[sortcolumn]), paramExpr);    
                        // apply the sort (default is ascending if not specified)
                        if (string.IsNullOrEmpty(sortdir) || sortdir.Equals(ASCENDING_SORT, StringComparison.OrdinalIgnoreCase))
                        {_queriable = _queriable.OrderBy(propertyExpr);}
                        else
                        {_queriable = _queriable.OrderByDescending(propertyExpr);}
                        break;*/
                }
            }
        }

        /// <summary>
        /// Expression that returns a list of string values, which correspond to the values
        /// of each property in the list type
        /// </summary>
        /// <remarks>This implementation does not allow indexers</remarks>
        private Expression<Func<T, List<string>>> SelectProperties
        {
            get
            {
                // 
                return value => _properties.Select
                                            (
                                                // empty string is the default property value
                                                prop => (prop.GetValue(value, new object[0]) ?? string.Empty).ToString()
                                            )
                                           .ToList();
            }
        }

        /// <summary>
        /// Compound predicate expression with the individual search predicates that will filter the results
        /// per an individual column
        /// </summary>
        private Expression<Func<T, bool>> IndividualPropertySearch
        {
            get
            {
                var paramExpr = Expression.Parameter(typeof(T), "val");
                Expression whereExpr = Expression.Constant(true); // default is val => True

                foreach (string key in _keys.Keys.Where(x => x.StartsWith(INDIVIDUAL_SEARCH_KEY_PREFIX)))
                {
                    // parse the property number
                    int property = -1;
                    if (!int.TryParse(_keys[key].Replace(INDIVIDUAL_SEARCH_KEY_PREFIX, string.Empty), out property) 
                        || property >= _properties.Length || string.IsNullOrEmpty(_keys[key]))
                        break; // ignore if the option is invalid

                    string query = _keys[key].ToLower();

                    // val.{PropertyName}.ToString().ToLower().Contains({query})
                    var toStringCall = Expression.Call(
                                        Expression.Call(
                                            Expression.Property(paramExpr, _properties[property]), "ToString", new Type[0]),
                                        typeof(string).GetMethod("ToLower", new Type[0]));
                    
                    // reset where expression to also require the current contraint
                    whereExpr = Expression.And(whereExpr, 
                                               Expression.Call(toStringCall, 
                                                               typeof(string).GetMethod("Contains"), 
                                                               Expression.Constant(query)));
                    
                }

                return Expression.Lambda<Func<T, bool>>(whereExpr, paramExpr);
            }
        }

        /// <summary>
        /// Expression for an all column search, which will filter the result based on this criterion
        /// </summary>
        private Expression<Func<T, bool>> ApplyGenericSearch
        {
            get
            {
                if (_keys.ContainsKey("sSearch")) { 
                    string search = _keys["sSearch"];

                    // default value
                    if (string.IsNullOrEmpty(search) || _properties.Length == 0)
                        return x => true;

                    // invariant expressions
                    var searchExpression = Expression.Constant(search.ToLower());
                    var paramExpression = Expression.Parameter(typeof(T), "val");

                    // query all properties and returns a Contains call expression 
                    // from the ToString().ToLower()
                    var propertyQuery = (from property in _properties
                                        let tostringcall = Expression.Call(
                                                            Expression.Call(
                                                                Expression.Property(paramExpression, property), "ToString", new Type[0]),
                                                                typeof(string).GetMethod("ToLower", new Type[0]))
                                        select Expression.Call(tostringcall, typeof(string).GetMethod("Contains"), searchExpression)).ToArray();

                    // we now need to compound the expression by starting with the first
                    // expression and build through the iterator
                    Expression compoundExpression = propertyQuery[0];

                    // add the other expressions
                    for (int i = 1; i < propertyQuery.Length; i++)
                        compoundExpression = Expression.Or(compoundExpression, propertyQuery[i]);

                    // compile the expression into a lambda 
                    return Expression.Lambda<Func<T, bool>>(compoundExpression, paramExpression);
                }
                else return x => true;
            }
        }
    }
    
    public class GridResponse
    {
        public GridResponse()
        {
        }

        public int sEcho { get; set; }
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public List<List<string>> aaData { get; set; } 
        public string sColumns { get; set; }

        public void Import(string[] properties)
        {
            sColumns = string.Empty;
            for (int i = 0; i < properties.Length; i++)
            {
                sColumns += properties[i];
                if (i < properties.Length - 1)
                    sColumns += ",";
            }
        }
    }
}

