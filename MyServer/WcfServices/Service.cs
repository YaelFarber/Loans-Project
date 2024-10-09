using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ViewModel;


namespace WcfServices
{
    public class Service : IService
    {
        //add
        public void AddDonation(Donation newDonation)
        {
            newDonation.dCode = MyDB.DonationDB.GetNextKey();
            MyDB.DonationDB.Add(newDonation);
            MyDB.DonationDB.SaveChanges();
        }

        public void AddLoan(Loan newLoan)
        {
            newLoan.LCode = MyDB.LoanDB.GetNextKey();
            MyDB.LoanDB.Add(newLoan);
            MyDB.LoanDB.SaveChanges();
        }

        public void AddPayment(Payment newPayment)
        {
            newPayment.pCode = MyDB.PaymentDB.GetNextKey();
            MyDB.PaymentDB.Add(newPayment);
            MyDB.PaymentDB.SaveChanges();
        }

        public void AddUser(MUser newUser)
        {
            MyDB.UserDB.Add(newUser);
            MyDB.UserDB.SaveChanges();
        }

        public void AddNeeman(Neeman newNeeman)
        {
            MyDB.NeemanDB.Add(newNeeman);
            MyDB.NeemanDB.SaveChanges();
        }


        //delete
        public void DeleteDonation(Donation donation)
        {
            MyDB.DonationDB.Delete(donation);
            MyDB.DonationDB.SaveChanges();
        }

        public void DeleteLoan(Loan loan)
        {
            MyDB.LoanDB.Delete(loan);
            MyDB.LoanDB.SaveChanges();
        }

        public void DeletePayment(Payment payment)
        {
            MyDB.PaymentDB.Delete(payment);
            MyDB.PaymentDB.SaveChanges();
        }

        public void DeleteUser(MUser user)
        {
            MyDB.UserDB.Delete(user);
            MyDB.UserDB.SaveChanges();
        }
        public void DeleteNeeman(Neeman neeman)
        {
            MyDB.NeemanDB.Delete(neeman);
            MyDB.NeemanDB.SaveChanges();
        }





        //get   
        public List<Donation> GetDonation()
        {
            return MyDB.DonationDB.GetList();
        }

        public Donation GetDonationByCode(int code)
        {
            return MyDB.DonationDB.GetDonationByCode(code);
        }

        public List<Loan> GetLoan()
        {
            return MyDB.LoanDB.GetList();
        }
        //פעולה המחזירה הלוואות לפי המשתמש
        public List<Loan> GetLoanById(MUser u)
        {
            List<Loan> lst = GetLoan().Where(x => x.Borrower.UserID == u.UserID && x.AllLoanReturned == false).ToList();
            return lst;

        }
        //פעולה המחזירה הלוואה לפי תעודת זהות לווה
        public List<Loan> GetLoanByUser(MUser u)
        {
            List < Loan >lst= GetLoan().Where(x => x.Borrower.UserID == u.UserID).ToList();
            return lst;
        }
        //פעולה המחזירה תשלומים לפי הלואה
        public List<Payment> GetPaymentByLoan(Loan l)
        {
            List<Payment> lst = GetPayments().Where(x => x.pAsk.LCode == l.LCode).ToList();
            return lst;
        }
        //פעולה המחזירה את הנאמנים
        public List<MUser> UserNeeman()
        {
            List<MUser> lst = GetUsers().Where(x => x.IsNeeman == true).ToList();
            return lst;
        }
        public Loan GetLoanByCode(int code)
        {
            return MyDB.LoanDB.GetLoanByCode(code);
        }
        //פעולה המחזירה משתמש לפי שם פרטי שהוא נאמן

        public MUser GetUserNeeman(string name)       
        { 
            MUser u = new MUser();
            List<MUser> lst = UserNeeman().Where(x => x.FirstLastName ==name).ToList();
            if(lst!=null && lst.Count>0) 
                u = lst[0];
            return u;
        }
        public MUser GetUserByName(string name)
        {
            MUser u = new MUser();
            List<MUser> lst = GetUsers().Where(x => x.FirstLastName == name).ToList();
            if (lst != null && lst.Count > 0)
                u = lst[0];
            return u;

        }
        public Payment GetPaymentByCode(int code)
        {
            return MyDB.PaymentDB.GetPaymentByCode(code);
        }

        public List<Payment> GetPayments()
        {
            return MyDB.PaymentDB.GetList();
        }

        public MUser GetUserByID(string id)
        {
            return MyDB.UserDB.GetUserByCode(id);
        }


        public List<MUser> GetUsers()
        {
            return MyDB.UserDB.GetList();
        }


        public List<Neeman> GetNeeman()
        {
            return MyDB.NeemanDB.GetList();
        }

        public Neeman GetNeemanByCode(int code)
        {
            return MyDB.NeemanDB.GetNeemanByCode(code);
        }

        public Neeman GetNeemanByName(string name)
        {
            List<Neeman> lst = GetNeeman().Where(x => x.nFirstLastName == name ).ToList();
          Neeman n=new Neeman();
            n.nCode = lst[0].nCode;
            n.nFirstLastName = lst[0].nFirstLastName;
            n.nPhone1 = lst[0].nPhone1;
            n.nPhone2 = lst[0].nPhone2;
            return n;
        }

        //update
        public void UpdateDonation(Donation donation)
        {
            MyDB.DonationDB.Update(donation);
            MyDB.DonationDB.SaveChanges();
        }

        public void UpdateLoan(Loan loan)
        {
            MyDB.LoanDB.Update(loan);
            MyDB.LoanDB.SaveChanges();
        }

        public void UpdatePayment(Payment payment)
        {
            MyDB.PaymentDB.Update(payment);
            MyDB.PaymentDB.SaveChanges();
        }

        public void UpdateUser(MUser user)
        {
            MyDB.UserDB.Update(user);
            MyDB.UserDB.SaveChanges();
        }
        public void UpdateNeeman(Neeman neeman)
        {
            MyDB.NeemanDB.Update(neeman);
            MyDB.NeemanDB.SaveChanges();
        }
        //פעולה הבודקת את שם המשתמש וסיסמא ומחזירה את המבוקש
        //public MUser GetUserByIDandPassword(string id, string password)
        //{
        //    return MyDB.UserDB.GetUserByIDandPassword(id, password);
        //}
        //פעולה המראה את התשלומים לפי לווה שנבנס 
        public List<Payment> GetPaymentByUser(string id)
        {
            return  MyDB.PaymentDB.GetList().Where (x => x.pAsk.Borrower.UserID==id).ToList ();
        }
        // מחזירה הלואות שעוד לא אושרו ושהזמן שלהם באותו חודש
        public List<Loan> GetLoanForConfirm()
        {

           return  MyDB.LoanDB. GetLoanForConfi();
        }

        public List<Loan> ArchivedLoans()
        {
            List<Loan> lst = GetLoan().Where(x => x.AllLoanReturned == true).ToList();
            return lst;
        }
      


   
    }
}
