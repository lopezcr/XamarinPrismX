using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPrismX.Model
{
    public class PantoneResponse
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<PantoneColor> data { get; set; }
    }
}
