using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Sell
    {
        public int Id { get; set; }
        public DateTime SellingDate { get; set; }
        public string? Name { get; set; }
        public int CountOfSold { get; set; }
        public double PriceOfSold { get; set; }
        public int VenorCode { get; set; }
        public Admission? Admission { get; set; }
    }
}
