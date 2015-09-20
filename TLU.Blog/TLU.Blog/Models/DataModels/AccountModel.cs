using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLU.Blog.Models.DataBase;
namespace TLU.Blog.Models.DataModels
{
    public class AccountModel
    {
        ThangLongEntities _db;
        public AccountModel()
        {
            _db = new ThangLongEntities();
        }
        public string GetNameById(int pId)
        {
            string str;
            var Object = _db.Accounts.Find(pId);
            if(Object.Profile.LangId == 0)
            {
                str = Object.Profile.SurName + ' ' + Object.Profile.FirstName;
            }
            else
            {
                str = Object.Profile.FirstName + ' ' + Object.Profile.SurName;
            }
            return str;
        }
    }
}
