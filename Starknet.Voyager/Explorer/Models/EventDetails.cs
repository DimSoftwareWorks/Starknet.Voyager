using System.Collections.Generic;

namespace Starknet.Voyager.Explorer.Models
{
    public class EventDetails
    {
        public int BlockNumber { get; set; }
        
        public int TransactionNumber { get; set; }
        
        public int Number { get; set; }
        
        public string FromAddress { get; set; }
        
        public string ClassHash { get; set; }
        
        public string TransactionHash { get; set; }
        
        public string BlockHash { get; set; }
        
        public int Timestamp { get; set; }

        /// <summary>
        /// Voyager assigned event id.
        /// </summary>
        public string EventId { get; set; }
        
        public string Name { get; set; }

        public string NestedName { get; set; }

        public string ContractAlias { get; set; }
        
        public string ClassAlias { get; set; }
        
        public string Selector { get; set; }
       
        public IEnumerable<string> Keys { get; set; } = new List<string>();

        public IEnumerable<string> Data { get; set; } = new List<string>();

        public IEnumerable<object> KeyDecoded { get; set; } = new List<object>();

        public IEnumerable<object> DataDecoded { get; set; } = new List<object>();
    }
}
