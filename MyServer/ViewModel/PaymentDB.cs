using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class PaymentDB:BaseDB
    {
        public PaymentDB() : base("Payment") { }
        public List<Payment> GetList()
        {
            Select();
            return base.list.Cast<Payment>().ToList();
        }

        protected override BaseEntity CreateModel()
        {
            Payment item = new Payment();
            item.pCode = Convert.ToInt32(reader["pCode"]);
            item.pAsk = MyDB.LoanDB.GetLoanByCode( Convert.ToInt32(reader["pAsk"]));
            item.pReturnedSum = Convert.ToInt32(reader["pReturnedSum"]);      
            item.ReturnedCheck = Convert.ToBoolean(reader["ReturnedCheck"]);
            item.Paid = Convert.ToBoolean(reader["Paid"]);
            item.pDate = Convert.ToDateTime(reader["pDate"]);
            return item;
        }
        public Payment GetPaymentByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.pCode == code);
        }

        protected override BaseEntity EqualsEntity(BaseEntity updatedEntity)
        {
            Payment updateItem = (Payment)updatedEntity;
            Payment item = MyDB.PaymentDB.GetPaymentByCode(updateItem.pCode);
            item.pCode = updateItem.pCode;
            item.pAsk = updateItem.pAsk;
            item.pReturnedSum = updateItem.pReturnedSum;
           
            item.ReturnedCheck = updateItem.ReturnedCheck;
            item.Paid = updateItem.Paid;
            item.pDate = updateItem.pDate;
            return item;
        }
        public int GetNextKey()
        {
            if (GetList().Count() == 0)
                return 1;
            return GetList().Max(x => x.pCode) + 1;
        }

    }
}
