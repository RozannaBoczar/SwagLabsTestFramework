using System.Collections.Generic;

namespace SwagLabsTestFramework.Data
{
    public class Summary
    {
        public decimal ItemTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string ShipInformation { get; set; }

        public string PayInformation { get; set; }
        public List<Product> Products { get; set; }

        public Summary() { }
    }
}
