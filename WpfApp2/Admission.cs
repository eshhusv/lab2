using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Admission
    {
        public int Id { get; set; }
        public int VenorCode { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public List<Sell> Sells { get; set; } = new();
    }
}
