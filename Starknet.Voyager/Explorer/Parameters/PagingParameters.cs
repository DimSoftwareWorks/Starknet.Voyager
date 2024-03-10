using Starknet.Voyager.Attributes;

namespace Starknet.Voyager.Explorer.Parameters
{
    public class PagingParameters
    {
        /// <summary>
        /// [ps] The number of items to to return in a page. 
        /// If it's less than 25, then the page size will be 10. If it's 25, then the page size will be 25. If it's greater than 25, then the page size will be 50.
        /// </summary>
        [QueryStringName("ps")]
        public int? PageSize { get; set; }

        /// <summary>
        /// [p] Which page of items to retrieve. Start with 1 unless you know which page you want. The JSON response body's lastPage field will indicate the last page you can iterate using such as 3.
        /// </summary>
        [QueryStringName("p")]
        public int? Page { get; set; }
    }
}
