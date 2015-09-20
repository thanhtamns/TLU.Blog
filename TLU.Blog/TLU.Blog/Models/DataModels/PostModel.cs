using System.Linq;
using PagedList;
using TLU.Blog.Models.DataBase;
namespace TLU.Blog.Models.DataModels
{
    public class PostModel
    {
        ThangLongEntities _db;
        public PostModel()
        {
            _db = new ThangLongEntities();
        }
        public bool Create(Post pNewPost)
        {
            try
            {
                _db.Posts.Add(pNewPost);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove(int pId)
        {
            try
            {
                _db.Posts.Remove(_db.Posts.Find(pId));
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(int pId,Post pNewPost)
        {
            try
            {
                var Object = _db.Posts.Find(pId);
                Object.AccountID = pNewPost.AccountID;
                Object.Descrip = pNewPost.Descrip;
                Object.UpFile = pNewPost.UpFile;
                Object.PostDate = pNewPost.PostDate;
                Object.PostContent = pNewPost.PostContent;
                Object.Like = pNewPost.Like;
                Object.Dislike = pNewPost.Dislike;
                Object.IsActive = pNewPost.IsActive;
                Object.LangId = pNewPost.LangId;
                Object.Permission = pNewPost.Permission;
                Object.ParentId = pNewPost.ParentId;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
        public PagedList<Post> GetPageListOrderByTime(int pPage,int pPageSize)
        {
            var result = _db.Posts.OrderByDescending(x => x.PostDate).ToPagedList(pPage, pPageSize);
            return result as PagedList<Post>;
        }
        public PagedList<Post> GetPageListOrderByLike(int pPage, int pPageSize)
        {
            var result = _db.Posts.OrderByDescending(x => x.Like).ToPagedList(pPage, pPageSize);
            return result as PagedList<Post>;
        }
        public PagedList<Post> GetPageListByIdTopic(int pId,int pPage, int pPageSize)
        {
            var result = _db.Posts.Where(x=>x.TopicID==pId).OrderByDescending(x => x.PostDate).ToPagedList(pPage, pPageSize);
            return result as PagedList<Post>;
        }
        public PagedList<Post> GetPageListByIdAccount(int pId, int pPage, int pPageSize)
        {
            var result = _db.Posts.Where(x => x.AccountID == pId).OrderByDescending(x => x.PostDate).ToPagedList(pPage, pPageSize);
            return result as PagedList<Post>;
        }
        public Post GetNewPostByAccountId(int pId)
        {
            var Object = _db.Posts.Where(x => x.AccountID == pId).OrderByDescending(x=>x.PostDate).FirstOrDefault();
            return Object;
        }
        public Post GetPostById(int pId)
        {
            return _db.Posts.Find(pId);
        }
    }
}
