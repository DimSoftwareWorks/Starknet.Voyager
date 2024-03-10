namespace Starknet.Voyager.Explorer.Models
{
    public class BlockDetailsExtended : BlockDetails
    {   
        public string PrevBlockHash { get; set; }
        
        public string NextBlockHash { get; set; }
        
        public int Confirmations { get; set; }
        
        public string SequencerAddress { get; set; }
        
        public int TimeToCreate { get; set; }
        
        public object L1AcceptTime { get; set; }
        
        public string GasPrice { get; set; }
        
        public string Version { get; set; }
    }
}
