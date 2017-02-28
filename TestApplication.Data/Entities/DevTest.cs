using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Data.Entities
{
    public class DevTest
    {
        public int ID { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string CampaignName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Clicks { get; set; }
        public Nullable<int> Conversions { get; set; }
        public Nullable<int> Impressions { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string AffiliateName { get; set; }
    }
}
