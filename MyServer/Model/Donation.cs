using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Donation:BaseEntity
    {
        public int dCode { get; set; }
        public string Donor { get; set; }
        public int dSum { get; set; }
        public string BankNum { get; set; }
        public string BankName { get; set; }
        public DateTime dDate { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "dCode" };
        }

        public override string GetTableName()
        {
            return "Donation";
        }
    }
}
