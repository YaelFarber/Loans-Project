using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Payment : BaseEntity
    {
        public int pCode { get; set; }
        public Loan pAsk { get; set; }
        public int pReturnedSum { get; set; }  
        public bool ReturnedCheck{get;set;}
        public bool Paid { get; set; }
        public DateTime pDate { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "pCode" };
        }

        public override string GetTableName()
        {
            return "Payment";
        }
    }
}
