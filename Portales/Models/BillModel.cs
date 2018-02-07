using System.Collections.Generic;

namespace Portales.Models
{
    public class BillModel
    {
        public string Number { get; set; }
        public int ClientId { get; set; }
        public ICollection<DetailModel> Details { get; set; }
    }
}