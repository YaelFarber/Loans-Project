using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class UserDB:BaseDB
    {
        public UserDB() : base("MyUser") { }
        public List<User> GetList()
        {
            Select();
            return base.list.Cast<User>().ToList();
        }

        protected override BaseEntity CreateModel()
        {
            User item = new User();
            item.UserID = reader["UserID"].ToString();
            item.FirstName = reader["FirstName"].ToString();
            item.LastName = reader["LastName"].ToString();
            item.Phone1 = reader["Phone1"].ToString();
            item.Phone2 = reader["Phone2"].ToString();
            item.uAddress = reader["uAddress"].ToString();
            item.uPassword = reader["uPassword"].ToString();
            item.uMail = reader["uMail"].ToString();
            item.IsNeeman = Convert.ToBoolean(reader["IsNeeman"]);
            item.IsArev = Convert.ToBoolean(reader["IsArev"]);
            return item;
        }
        public User GetUserByCode(string code)
        {
            return GetList().FirstOrDefault(x => x.UserID == code);
        }
        protected override BaseEntity EqualsEntity(BaseEntity updatedEntity)
        {
            User updateItem = (User)updatedEntity;
            User item = MyDB.UserDB.GetUserByCode(updateItem.UserID);
            item.UserID = updateItem.UserID;
            item.FirstName = updateItem.FirstName;
            item.LastName = updateItem.LastName;
            item.Phone1 = updateItem.Phone1;
            item.Phone2 = updateItem.Phone2;
            item.uAddress = updateItem.uAddress;
            item.uPassword = updateItem.uPassword;
            item.uMail = updateItem.uMail;
            item.IsNeeman = updateItem.IsNeeman;
            item.IsArev = updateItem.IsArev;

            return item;
        }
        //פעולה הבודקת את שם המשתמש וסיסמא ומחזירה את המבוקש
        public User GetUserByIDandPassword(string id, string password)
        {
            return MyDB.UserDB.GetList().FirstOrDefault(x => x.UserID == id && x.uPassword == password);
        }
    }
}
