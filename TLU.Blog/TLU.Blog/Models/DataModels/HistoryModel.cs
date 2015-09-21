using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLU.Blog.Models.DataBase;
using PagedList;
namespace TLU.Blog.Models.DataModels
{
    public class HistoryModel
    {
        ThangLongEntities _db;
        public HistoryModel()
        {
            _db = new ThangLongEntities();
        }
        public PagedList<History> GetPageListHistory(int pPage,int pPageSize)
        {
            return _db.Histories.OrderByDescending(x => x.Time).ToPagedList(pPage, pPageSize) as PagedList<History>;
        }
        public PagedList<History> GetPageListHistoryIsActive(int pPage, int pPageSize)
        {
            return _db.Histories.OrderByDescending(x => x.Time).Where(x=>x.IsActive==true).ToPagedList(pPage, pPageSize) as PagedList<History>;
        }
        public PagedList<History> GetPageListHistoryByAccountId(int pAccountId,int pPage, int pPageSize)
        {
            return _db.Histories.OrderByDescending(x => x.Time).Where(x=>x.AccountID==pAccountId).ToPagedList(pPage, pPageSize) as PagedList<History>;
        }
        public History GetHistoryById(int pHistoryId)
        {
            return _db.Histories.Find(pHistoryId);
        }
        public string GetNameAccountById(int? pAccountId)
        {
            string str;
            var Object = _db.Accounts.Find(pAccountId);
            if (Object.Profile.LangId == 0)
            {
                str = Object.Profile.SurName + ' ' + Object.Profile.FirstName;
            }
            else
            {
                str = Object.Profile.FirstName + ' ' + Object.Profile.SurName;
            }
            return str;
        }
        public void Hide(int pId)
        {
            _db.Histories.Find(pId).IsActive = false;
            _db.SaveChanges();
        }
    }
}
