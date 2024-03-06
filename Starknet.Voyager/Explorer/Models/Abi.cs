using System.Collections.Generic;

namespace Starknet.Voyager.Explorer.Models
{
    public class Abi
    {
        public IEnumerable<Member> Members { get; set; } = new List<Member>();
        
        public string Name { get; set; }
        
        public int Size { get; set; }
        
        public string Type { get; set; }
        
        public IEnumerable<Input> Inputs { get; set; } = new List<Input>();

        public IEnumerable<Output> Outputs { get; set; } = new List<Output>();
        
        public string StateMutability { get; set; }
    }
}
