using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class MyDB
    {
        public static DonationDB DonationDB = new DonationDB();     
        public static LoanDB LoanDB = new LoanDB();
        public static MyUserDB UserDB = new MyUserDB();
        public static PaymentDB PaymentDB = new PaymentDB();
        public static NeemanDB NeemanDB = new NeemanDB();
    }
}
