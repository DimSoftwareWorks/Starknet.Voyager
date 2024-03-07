using Starknet.Voyager.Attributes;

namespace Starknet.Voyager.Explorer.Parameters
{
    public class GetContractsParameters : PagingParameters
    {
        /// <summary>
        /// If true, only accounts will be returned. If false, only contracts will be returned. If not specified, both will be returned.
        /// </summary>
        [QueryStringName("account")]
        public int Account { get; set; }
    }
}
