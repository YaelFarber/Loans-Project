using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ViewModel;
using Model;

namespace WcfServices
{
    [ServiceContract]
    interface IService
    {
        //user
        [OperationContract]
        List<MUser> GetUsers();
        [OperationContract]
        void AddUser(MUser newUser);
        [OperationContract]
        void UpdateUser(MUser user);
        [OperationContract]
        void DeleteUser(MUser user);
        [OperationContract]
        MUser GetUserByID(string id);
        [OperationContract]
        List<MUser> UserNeeman();
        [OperationContract]
        MUser GetUserNeeman(string name);
        [OperationContract]
        MUser GetUserByName(string name);

        //payment
        [OperationContract]
        List<Payment> GetPayments();
        [OperationContract]
        void AddPayment(Payment newPayment);
        [OperationContract]
        void UpdatePayment(Payment payment);
        [OperationContract]
        void DeletePayment(Payment payment);
        [OperationContract]
        Payment GetPaymentByCode(int code);






        //loan
        [OperationContract]
        List<Loan> GetLoan();
        [OperationContract]
        void AddLoan(Loan newLoan);
        [OperationContract]
        void UpdateLoan(Loan loan);
        [OperationContract]
        void DeleteLoan(Loan loan);
        [OperationContract]
        Loan GetLoanByCode(int code);
        [OperationContract]
        List<Loan> GetLoanById(MUser u);
        [OperationContract]
        List<Loan> GetLoanByUser(MUser u);
        [OperationContract]
        List<Payment> GetPaymentByLoan(Loan l);
        [OperationContract]
        List<Loan> GetLoanForConfirm();
        [OperationContract]
        List<Loan> ArchivedLoans();

        //donation
        [OperationContract]
        List<Donation> GetDonation();
        [OperationContract]
        void AddDonation(Donation newDonation);
        [OperationContract]
        void UpdateDonation(Donation donation);
        [OperationContract]
        void DeleteDonation(Donation donation);
        [OperationContract]
        Donation GetDonationByCode(int code);

        //neeman
        [OperationContract]
        List<Neeman> GetNeeman();
        [OperationContract]
        void AddNeeman(Neeman newNeeman);
        [OperationContract]
        void UpdateNeeman(Neeman neeman);
        [OperationContract]
        void DeleteNeeman(Neeman neeman);
        [OperationContract]
        Neeman GetNeemanByCode(int code);
        [OperationContract]
        Neeman GetNeemanByName(string name);







        //פעולה הבודקת את שם המשתמש וסיסמא ומחזירה את המבוקש
        //[OperationContract]
        //MUser GetUserByIDandPassword(string id, string password);
        //פעולה הנותנת את התשלומים לפי לקוח שנכנס
        [OperationContract]
        List<Payment> GetPaymentByUser(string id);
    }
}
