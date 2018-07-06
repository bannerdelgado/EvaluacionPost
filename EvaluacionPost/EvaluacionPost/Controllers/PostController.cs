using EvaluacionPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvaluacionPost.Controllers
{
    public class PostController : Controller
    {

        private static int PostId = 1;

        private static readonly List<Category> Categories =
            new List<Category>
            {
                new Category { id=1,name="Comida"},
                new Category { id=2,name="Deportes"},
                new Category { id=3,name="Musica"},
                new Category { id=4,name="Cine"},
                new Category { id=5,name="Tecnologia"},
                new Category { id=6,name="Otros"}
            };


        private static List<Post> Posts =
            new List<Post>
            {
                new Post {id=PostId++, title="Comida",date=DateTime.Now,content="Este es un articulo en blanco",category=Categories[0]},
                new Post {id=PostId++, title="Mundial",date=DateTime.Now,content="Este es un articulo en blanco",category=Categories[1]},
                new Post {id=PostId++, title="New album of a band",date=DateTime.Now,content="Este es un articulo en blanco",category=Categories[2]},
            };


        // GET: Post
        public ActionResult Index()
        {
            return View(Posts);
        }

        public ActionResult Create()
        {
            return View(Categories);
        }

        [HttpPost]
        public ActionResult Create(Post post, int category)
        {

            var postStatus = Categories.FirstOrDefault(x => x.id == category);
            post.category = postStatus;
            post.id = PostId++;
            Posts.Add(post);
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            var postToEdit = Posts.FirstOrDefault(x => x.id == id);
            if (postToEdit == null) return RedirectToAction("Index");

            var viewModel = new EditViewModel()
            {

                post = postToEdit,
                category = Categories

            };

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Edit(Post p)
        {
            var postToEdit = Posts.FirstOrDefault(x => x.id == p.id);
            if (postToEdit == null) return RedirectToAction("Index");

            //TODO:Actualizar categoria 
            // var postToCategory = Categories.Where(x => x.id == p.category.id).FirstOrDefault();


            postToEdit.title = p.title;
            //postToEdit.category= postToCategory;
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            var postToDelete = Posts.FirstOrDefault(x => x.id == id);
            if (postToDelete == null) return RedirectToAction("Index");

            return View(postToDelete);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Posts.RemoveAll(x => x.id == id.Value);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Show(int id)
        {
            var postToShow = Posts.FirstOrDefault(x => x.id == id);
            if (postToShow == null) return RedirectToAction("Index");

            return View(postToShow);

        }

        public ActionResult Comment(Post post)
        {
            return HttpNotFound();
        }
    }
}