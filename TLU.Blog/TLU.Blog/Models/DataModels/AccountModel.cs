using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLU.Blog.Models.DataBase;
using TLU.Blog.Models.DataViews;
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
        public Profile GetProfileById(int pAccountId)
        {
            return _db.Accounts.Find(pAccountId).Profile;
        }
        public List<History> GetHistoryById(int pAccountId)
        {
            return _db.Accounts.Find(pAccountId).Histories.ToList();
        }
        public bool ChangeProfile(int pAccountId, Profile pNewProfile)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CreateAccount (AccountView pNewAccount )
        {
            try
            {

                return true;
            }
            catch
            {
                return false;
            }
        }
        public string LogInAdmin(Account pAccountAdmin)
        {
            try
            {
                return "";
            }
            catch
            {
                return "";
            }
        }
        public string LogInBlog(Account pAccountBlog)
        {
            try
            {
                return "";
            }
            catch
            {
                return "";
            }
        }
    }
}
