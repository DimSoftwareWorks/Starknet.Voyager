using System.Collections.Generic;

namespace Starknet.Voyager.Explorer.Models
{
    public class EventsListDetails
    {
        public int LastPage { get; set; }

        public IEnumerable<EventDetails> Items { get; set; } = new List<EventDetails>();
    }
}
