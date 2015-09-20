using System;
using System.Collections.Generic;
using System.Linq;
using TLU.Blog.Data;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Helpers;
using TLU.Blog.DataViews;
using TLU.Blog.DataModels;
namespace TLU.Blog.Controllers
{
    public class HomeController : BaseController
    {
        ThangLongEntities _db;
        public HomeController()
        {
            _db = new ThangLongEntities();
        }
        private const int IdAccount = 15;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult New()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Awnser()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ChangeLanguage(string Id)
        {
            // vi
            TLUResourceManager.SetLanguage(Id);

            BlogLang.SetLanguage(Id);

            return RedirectToAction("Index");

        }
        public ActionResult NewPost()
        {
            ViewBag.ListTopic = new TopicModel().GetListTopic();
            return View();
        }
        [HttpPost]
        public ActionResult NewPost(PostView pNewPost)
        {
            try {
                HttpPostedFileBase file = HttpContext.Request.Files["pImage"];
                string a = "/Image/" + file.FileName;
                string b = Server.MapPath(a);
                file.SaveAs(b);
                var Object = new Data.Post();
                Object.Descrip = pNewPost.pDescrip;
                Object.PostContent = pNewPost.pContent;
                Object.TopicID = new TopicModel().GetIdByName(pNewPost.pNameTopic);
                Object.AccountID = IdAccount;
                Object.PostDate = DateTime.Now;
                Object.Image = a;
                Object.Like = 0;
                Object.Dislike = 0;
                Object.IsActive = true;
                Object.LangId = 0;
                Object.Permission = 1;
                Object.ParentId = 0;
                bool check = new PostModel().Create(Object);
                var Result = new PostModel().GetNewPostByAccountId(IdAccount).ID;
                if (check)
                {
                    return RedirectToAction("Post", "Home", new { id = Result });
                }
                else
                {
                    ViewBag.ListTopic = new TopicModel().GetListTopic();
                    return View();
                }
            }
            catch
            {
                ViewBag.ListTopic = new TopicModel().GetListTopic();
                return View();
            }
        }

        public ActionResult Post(int id)
        {
            ViewBag.ListTopic = new TopicModel().GetListTopic();
            var result = new PostModel().GetPostById(id);
            return View(result);
        }

        public ActionResult ViewLike(int pId)
        {
            new VotesModel().ChangeLike(15, pId);
            var result = new PostModel().GetPostById(pId);
            return View(result);
        }

        public ActionResult ViewComment(string pContent, int pPostId)
        {
            ViewBag.PostId = pPostId;
            var Object =  new Comment();
            Object.CommentDate = DateTime.Now;
            Object.AccountID = IdAccount;
            Object.ParentId = 0;
            Object.CommentLike = 0;
            Object.CommentDislike = 0;
            Object.CommentContent = pContent;
            Object.IsActive = true;
            Object.LangId = 0;
            Object.PostID = pPostId;
            new CommentModel().Create(Object);
            return View();
        }
        
        public ActionResult ViewReply(string pReplyContent,int pCommentId)
        {
            var Object = new Comment();
            Object.CommentDate = DateTime.Now;
            Object.AccountID = IdAccount;
            Object.ParentId = pCommentId;
            Object.CommentLike = 0;
            Object.CommentDislike = 0;
            Object.CommentContent = pReplyContent;
            Object.IsActive = true;
            Object.LangId = 0;
            Object.PostID = new CommentModel().GetPostIdByCommnetParentId(pCommentId);
            new CommentModel().Create(Object);
            return View(pCommentId);
        }
        public int CountComment(int pPostId)
        {
            return new CommentModel().GetCountComment(pPostId);
        }
        public ActionResult AutoCountLike(int pPostId)
        {
            var result = new PostModel().GetPostById(pPostId);
            return View(result);
        }
        public ActionResult AutoListComment(int pPostId)
        {
            ViewBag.PostId = pPostId;
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(Account ac)
        {
            if (ModelState.IsValid)
            {
                _db.Accounts.Add(ac);
                _db.SaveChanges();
            }

            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection fm)
        {
            string sTaiKhoan = fm.Get("txtTaiKhoan").ToString();
            string sMatKhau = fm.Get("txtMatKhau").ToString();
            Account ac1 = _db.Accounts.SingleOrDefault(n => n.UserName == sTaiKhoan && n.Password == sMatKhau);
            if (ac1 != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công !";
                Session["TaiKhoan"] = ac1;
                return View();
            }
            ViewBag.ThongBao = "Tài khoản hoặc mật khẩu chưa chính xác !";
            return View();
        }
    }
}