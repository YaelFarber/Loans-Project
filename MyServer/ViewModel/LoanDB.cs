using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
  public  class LoanDB:BaseDB
    {
        public LoanDB() : base("Loan") { }
        public List<Loan> GetList()
        {
            Select();
            return base.list.Cast<Loan>().ToList();
        }

        protected override BaseEntity CreateModel()
        {
            Loan item = new Loan();
            item.LCode = Convert.ToInt32(reader["LCode"]);
            item.Borrower = MyDB.UserDB.GetUserByCode( reader["Borrower"].ToString());
            item.LSum = Convert.ToInt32(reader["LSum"]);
            item.VerbalSum = reader["VerbalSum"].ToString();
            item.AskDate = Convert.ToDateTime(reader["AskDate"]);
            item.RequestedDate = Convert.ToDateTime(reader["RequestedDate"]);
            item.PaymentsType = reader["PaymentsType"].ToString();
            item.PaymentsNum = Convert.ToInt32(reader["PaymentsNum"]);
            item.FirstPayment = Convert.ToDateTime(reader["FirstPayment"]);
            item.Arev1 = reader["Arev1"].ToString();
            item.Arev2 = reader["Arev2"].ToString();
            item.Neeman = MyDB.NeemanDB.GetNeemanByCode  (Convert.ToInt32( reader["Neeman"]));
            item.Confirmed = Convert.ToBoolean(reader["Confirmed"]);
            //item.ConfirmedDate = Convert.ToDateTime(reader["ConfirmedDate"]);
            item.AllLoanReturned = Convert.ToBoolean(reader["AllLoanReturned"]);
            return item;
        }
        public Loan GetLoanByCode(int code)
        {
            return GetList().FirstOrDefault(x => x.LCode == code);
        }
        // מחזירה הלואות שעוד לא אושרו ושהזמן שלהם באותו חודש
        public  List< Loan> GetLoanForConfi()
        {
            return GetList().Where (x => x.Confirmed  == false && x.AskDate.Year ==DateTime .Today .Year  ).ToList ();
        }
        protected override BaseEntity EqualsEntity(BaseEntity updatedEntity)
        {
            Loan updateItem = (Loan)updatedEntity;
            Loan item = MyDB.LoanDB.GetLoanByCode(updateItem.LCode);
            item.LCode = updateItem.LCode;
            item.Borrower = updateItem.Borrower;
            item.LSum = updateItem.LSum;
            item.VerbalSum = updateItem.VerbalSum;
            item.AskDate = updateItem.AskDate;
            item.RequestedDate = updateItem.RequestedDate; ;
            item.PaymentsType = updateItem.PaymentsType;
            item.PaymentsNum = updateItem.PaymentsNum;
            item.FirstPayment = updateItem.FirstPayment;
            item.Arev1 = updateItem.Arev1;
            item.Arev2 = updateItem.Arev2;
            item.Neeman = updateItem.Neeman;
            item.Confirmed = updateItem.Confirmed;
          //  item.ConfirmedDate = updateItem.ConfirmedDate;
            item.AllLoanReturned = updateItem.AllLoanReturned;
            return item;
        }
        public int GetNextKey()
        {
            if (GetList().Count() == 0)
                return 1;
            return GetList().Max(x => x.LCode) + 1;
        }
    }
}
