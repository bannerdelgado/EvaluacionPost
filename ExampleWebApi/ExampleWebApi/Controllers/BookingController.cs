using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ExampleWebApi.Models;
using ExampleWebApi.ViewModel;
using Newtonsoft.Json;

namespace ExampleWebApi.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }
        //private List<User> GetUsers()
        //{
            /*try
            {
                var ResultL = new List<User>();
                var client = new HttpClient();
                //var getDaTask = client.GetAsync("").
                  /*  ConfigureAwait(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAnsyc<List<User>>();
                            readResult.Wait();

                            ResultL = readResult.Result;
                        }

                    }
                    );
            }

            catch(Exeption e)
            {
                return e;
            }
            return Resulltl;

        }
        */
        public ActionResult Create()
        {
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:51514/api/User");

            //    //HTTP POST
            //    var postTask = client.PostAsJsonAsync<ResultViewModel>("User", resultViewModel);
            //    postTask.Wait();

            //    var result = postTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //}

            //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View();

            
        }


        private static async Task<string> GetData()
        {
            string url = "http://localhost:51514/api/User";

            HttpClient Client = new HttpClient();

            string content = await Client.GetStringAsync(url);

            return content;

        }




        public ActionResult Result()
        {
            IEnumerable<ResultViewModel> user = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51514/api/User");
                //HTTP GET
                var responseTask = client.GetAsync("User");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ResultViewModel>>();
                    readTask.Wait();

                    user = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    user = Enumerable.Empty<ResultViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(user);


        }
    }
}