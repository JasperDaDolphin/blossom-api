namespace Blossom.Api.Model
{
    public abstract class SortedSearchRequest
    {
        public string OrderBy { get; set; }
        public string OrderDirection { get; set; }
    }
}