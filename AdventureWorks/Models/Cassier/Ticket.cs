using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventureWorks.Models.Cassier
{
    public class Ticket
    {
        public string ClientCardId { get; set; }
        public string CassierId { get; set; }
        public DateTime CheckoutTime { get; set; }
        public IEnumerable<Article> Articles { get; set; }

        public decimal TotalPrice => Articles.Sum(a => a.PriceTotal);
    }
}
