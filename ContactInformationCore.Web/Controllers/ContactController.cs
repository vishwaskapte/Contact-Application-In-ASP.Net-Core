using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ContactInformationCore.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContactInformationCore.Web.Controllers
{
    public class ContactController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "https://localhost:44323/api/Contacts";

        public ContactController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var contact = JsonConvert.DeserializeObject<List<Contact>>(responseData);

                return View(contact);
            }
            return View("Error");
        }

        //public JsonResult LoadAllContacts()
        //{
        //    try
        //    {
        //        var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
        //        var start = Request.Form["start"].FirstOrDefault();
        //        var length = Request.Form["length"].FirstOrDefault();
        //        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        //        var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
        //        var searchValue = Request.Form["search[value]"].FirstOrDefault();

        //        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        //        int skip = start != null ? Convert.ToInt32(start) : 0;
        //        int recordsTotal = 0;

        //        if (!string.IsNullOrEmpty(Convert.ToString("Admin")))
        //        {

        //            var v = _IBookingVenue.ShowAllBookingUser(sortColumn, sortColumnDir, searchValue, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
        //            recordsTotal = v.Count();
        //            var data = v.Skip(skip).Take(pageSize).ToList();
        //            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        //        }
        //        else
        //        {
        //            return Json("Failed");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}