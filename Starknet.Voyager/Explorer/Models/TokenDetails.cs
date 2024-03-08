using Starknet.Voyager.Explorer.Enumerations;

namespace Starknet.Voyager.Explorer.Models
{
    public class TokenDetails
    {
        public string Address { get; set; }
        
        public TokenType Type { get; set; }
        
        public string Name { get; set; }
        
        public string Symbol { get; set; }
        
        public int Decimals { get; set; }
        
        public string Transfers { get; set; }
        
        public string Holders { get; set; }
    }
}
