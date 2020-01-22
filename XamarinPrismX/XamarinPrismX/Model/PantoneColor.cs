using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPrismX.Model
{
    public class PantoneColor
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public string pantone_value { get; set; }

        public string Image { get; set; } = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/my-hero-academia-4-trailer-1567404314.jpg";
    }
}
