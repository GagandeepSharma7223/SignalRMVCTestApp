using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApplication.Service.Models
{
    public class TestAppModel
    {
        public int ID { get; set; }
        [Required, Display(Name = "Campaign Name")]
        public string CampaignName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int Clicks { get; set; }
        public int Conversions { get; set; }
        public int Impressions { get; set; }
        [Required, Display(Name = "Affiliate Name")]
        public string AffiliateName { get; set; }
    }
}