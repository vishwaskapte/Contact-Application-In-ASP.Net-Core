using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ContactInformationCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Logging;

namespace ContactInformationCore.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger _logger;

        HttpClient client;
        //The URL of the WEB API Service
        string url = "https://localhost:44323/api/Contacts";

        public ContactController(ILoggerFactory logFactory)
        {
            _logger = logFactory.CreateLogger<ContactController>();

            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Log message in the HttpGet Contact Controller => Index() method");
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var contact = JsonConvert.DeserializeObject<List<Contact>>(responseData);
                
                //LoadAllContacts();

                return View(contact);
            }
            return View("Error");
        }

        public ActionResult Create()
        {
            return View(new Contact());
        }

        //The Post method
        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            string json = JsonConvert.SerializeObject(contact, Formatting.Indented);
            HttpContent contactContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(url, contactContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _logger.LogInformation("New Contact has been Created ! Redirected to Index Page");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _logger.LogInformation(" Redirected to Details Page");
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var contact = JsonConvert.DeserializeObject<Contact>(responseData);

                return View(contact);
            }
            return View("Error");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var contact = JsonConvert.DeserializeObject<Contact>(responseData);

                _logger.LogInformation(" Redirected to Edit Page");

                return View(contact);
            }
            return View("Error");
        }
        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Contact contacttoUpdate)
        {
            string json = JsonConvert.SerializeObject(contacttoUpdate, Formatting.Indented);
            HttpContent ContactContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PutAsync(url + "/" + id, ContactContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _logger.LogInformation("User " + contacttoUpdate.First_Name + " " + "Edited Successfully !");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var contact = JsonConvert.DeserializeObject<Contact>(responseData);

                return View(contact);
            }
            return View("Error");
        }

        //The DELETE method
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Contact contact)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _logger.LogInformation("User " + contact.First_Name + " " + "Deleted Successfully !");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
    }
}