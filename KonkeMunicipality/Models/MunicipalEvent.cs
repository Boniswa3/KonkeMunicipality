
using System;

namespace KonkeMunicipality.Models
{
    public class MunicipalEvent
    {
        public string EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
    }
}
