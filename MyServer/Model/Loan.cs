using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Loan:BaseEntity
    {
       public int LCode { get; set; }
        public MUser Borrower { get; set; }
        public int LSum { get; set; }
        public string VerbalSum { get; set; }
        public DateTime AskDate { get; set; }
        public DateTime RequestedDate { get; set; }
        public string PaymentsType { get; set; }
        public int PaymentsNum { get; set; }
        public DateTime FirstPayment { get; set; }
        public string Arev1 { get; set; }
        public string Arev2 { get; set; }
        public Neeman Neeman { get; set; }
        public bool Confirmed { get; set; }
    
        public bool AllLoanReturned { get; set; }

        public override string[] GetKeyFields()
        {
            return new string[] { "LCode" };
        }

        public override string GetTableName()
        {
            return "Loan";
        }
    }
}
