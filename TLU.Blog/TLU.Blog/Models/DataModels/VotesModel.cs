using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLU.Blog.Models.DataBase;
namespace TLU.Blog.Models.DataModels
{
    public class VotesModel
    {
        ThangLongEntities _db;
        public VotesModel()
        {
            _db = new ThangLongEntities();
        }
        public bool Create(Vote pNewVote)
        {
            try
            {
                _db.Votes.Add(pNewVote);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool IsExist(int pAccountId,int pPostId)
        {
            var result = _db.Votes.Where(x => x.AccountId == pAccountId).Where(x => x.PostId == pPostId).SingleOrDefault();
            if (result == null)
                return false;
            else
                return true;
        }
        public bool IsActive(int pAccountId, int pPostId)
        {
            var result = _db.Votes.Where(x => x.AccountId == pAccountId).Where(x => x.PostId == pPostId).SingleOrDefault();
            if(result==null)
            {
                return false;
            }
            else
            {
                return result.IsActive==true;
            }
        }
        public int CountLikeByPostId(int pPostId)
        {
            return _db.Votes.Where(x => x.PostId == pPostId).Where(x => x.Like == true).ToList().Count;
        }
        public bool IsLike(int pAccountId, int pPostId)
        {
            var result = _db.Votes.Where(x => x.AccountId == pAccountId).Where(x => x.PostId == pPostId).SingleOrDefault();
            return result.Like==true;
        }
        public bool ChangeLike(int pAccountId, int pPostId)
        {
            try
            {
                var result = _db.Votes.Where(x => x.AccountId == pAccountId).Where(x => x.PostId == pPostId).SingleOrDefault();
                var post = _db.Posts.Find(pPostId);
                if(result.Like==true)
                {
                    post.Like = post.Like - 1;
                    result.Like = false;
                }
                else
                {
                    post.Like = post.Like + 1;
                    result.Like = true;
                }
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
