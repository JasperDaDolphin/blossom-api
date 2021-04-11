using System.Collections.Generic;

namespace Blossom.Service.Model
{
    public class SearchResult<TModel>
    {
        public int TotalCount { get; set; }
        public List<TModel> Results { get; set; }
    }
}