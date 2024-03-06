using Starknet.Voyager.Explorer.Enumerations;

namespace Starknet.Voyager.Explorer.Models
{
    public class TokenDetails
    {
        public string Address { get; set; }
        
        public TokenType type { get; set; }
        
        public string Name { get; set; }
        
        public string Symbol { get; set; }
        
        public int decimals { get; set; }
        
        public string transfers { get; set; }
        
        public string holders { get; set; }
    }
}
