using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class MyUserDB:BaseDB
    {
        public MyUserDB() : base("MyUser") { }
        public List<MUser> GetList()
        {
            Select();
            return base.list.Cast<MUser>().ToList();
        }

        protected override BaseEntity CreateModel()
        {
            MUser item = new MUser();
            item.UserID = reader["UserID"].ToString();
            item.FirstLastName = reader["FirstLastName"].ToString();           
            item.Phone1 = reader["Phone1"].ToString();
            item.Phone2 = reader["Phone2"].ToString();
            item.uAddress = reader["uAddress"].ToString();
            item.uMail = reader["uMail"].ToString();
            item.IsNeeman = Convert.ToBoolean(reader["IsNeeman"]);
            return item;
        }
        public MUser GetUserByCode(string code)
        {
            return GetList().FirstOrDefault(x => x.UserID == code);
        }
        protected override BaseEntity EqualsEntity(BaseEntity updatedEntity)
        {
            MUser updateItem = (MUser)updatedEntity;
            MUser item = MyDB.UserDB.GetUserByCode(updateItem.UserID);
            item.UserID = updateItem.UserID;
            item.FirstLastName = updateItem.FirstLastName;
            item.Phone1 = updateItem.Phone1;
            item.Phone2 = updateItem.Phone2;
            item.uAddress = updateItem.uAddress;
            item.uMail = updateItem.uMail;
            item.IsNeeman = updateItem.IsNeeman;

            return item;
        }
        //פעולה הבודקת את שם המשתמש וסיסמא ומחזירה את המבוקש
        //public MUser GetUserByIDandPassword(string id, string password)
        //{
        //    return MyDB.UserDB.GetList().FirstOrDefault(x => x.UserID == id && x.uPassword == password);
        //}
    }
}
