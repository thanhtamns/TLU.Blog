using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLU.Blog.Models.DataBase;
namespace TLU.Blog.Models.DataModels
{
    public class TopicModel
    {
        ThangLongEntities _db;
        public TopicModel()
        {
            _db = new ThangLongEntities();
        }
        public List<string> GetListNameTopic()
        {
            var Object= _db.Topics.ToList();
            List<string> result= new List<string>();
            foreach (var item in Object)
            {
                result.Add(item.Name);
            }
            return result;
        }
        public int? GetIdByName(string pName)
        {
            return _db.Topics.Where(x => x.Name == pName).SingleOrDefault().ID;
        }
        public string GetNameById(int? pId)
        {
            return _db.Topics.Find(pId).Name;
        }
        public List<Topic> GetListTopic()
        {
            return _db.Topics.ToList();
        }
    }
}
