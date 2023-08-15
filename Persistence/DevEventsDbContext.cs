using safemoney.API.Entities;

namespace safemoney.API.Persistence
{
   
    public class DevEventsDbContext
    {
        public DevEventsDbContext()
        {
            DevEvents = new List<DevEvent>();
        }
        public List<DevEvent> DevEvents { get; set; }
    }
}