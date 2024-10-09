using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Deposits : BaseEntity
    {
        public int DepositCode {get;set;}
        public User Deposit { get; set; }
        public int DepositSum { get; set; }
        public DateTime dTime { get; set; }
       
      
        public override string[] GetKeyFields()
        {
            return new string[] { "DepositCode" };
        }

        public override string GetTableName()
        {
            return "Deposits";
        }
    }
}
