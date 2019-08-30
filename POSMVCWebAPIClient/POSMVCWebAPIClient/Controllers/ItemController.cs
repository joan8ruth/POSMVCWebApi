using POSMVCWebAPIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace POSMVCWebAPIClient.Controllers
{
    public class ItemController : Controller
    {
        public static List<Item> ItemList = new List<Item>();
        public static int i = 0;
        public static string itemAvailability = "";

        // GET: Item
        public ActionResult Index()
        {
            ViewBag.message = itemAvailability;
            return View();
        }

        public ActionResult ScanItem()
        {

            return PartialView();

        }

        public ActionResult DisplayItemList()
        {

            return PartialView(ItemList);
        }

        public ActionResult Delete(int id)
        {
            Item item = new Item();
            var query = ItemList.Where(i => i.Index == id);
            foreach (var i in query)
            {
                item = i;
            }

            ItemList.Remove(item);

            return RedirectToAction("Index");
        }

        public ActionResult CheckItemAvailability(int ItemId) //parameter should be same as field name , not case sensitive
        {

            string apiURI = "http://localhost:53297/api/Items/";
            apiURI = apiURI + ItemId.ToString();
            var client = new HttpClient();

            var response = client.GetAsync(apiURI);

            string op = "";
            Item item;

            if (response.Result.IsSuccessStatusCode)
            {
                using (HttpContent cont = response.Result.Content)
                {
                    Task<string> res = cont.ReadAsStringAsync();
                    op = res.Result;

                    //User user=JsonConvert.DeserializeObject<User>
                    JavaScriptSerializer js = new JavaScriptSerializer();

                    item = js.Deserialize<Item>(op);

                }

                item.Index = i;

                ItemList.Add(item);
                i++;
                itemAvailability = "";


                return RedirectToAction("Index");

            }

            else
            {
                itemAvailability = "Item not available";
                return RedirectToAction("Index");

            }

        }

    }
}