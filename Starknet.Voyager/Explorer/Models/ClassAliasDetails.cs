using Newtonsoft.Json;

namespace Starknet.Voyager.Explorer.Models
{
    public class ClassAliasDetails
    {
        public string Alias { get; set; }

        [JsonProperty("verified_timestamp")]
        public int? VerifiedTimestamp { get; set; }
    }
}
