using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModel = PayCalculatorWebApplication.Models.ViewModel;

namespace PayCalculatorWebApplication.Controllers
{
    //[Route("[controller]")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ViewModel> employeeList = new List<ViewModel>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync("http://localhost:65386/Employee");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employeeList = JsonConvert.DeserializeObject<List<ViewModel>>(apiResponse);
                }
                return View(employeeList);
            }
            catch (Exception ex)
            {
                throw new Exception("The warning is" + ex);
            }
        }

        public async Task displayEmployeeAsync()
        {
            using (var httpClient = new HttpClient())
            {
                List<ViewModel> employeeList = new List<ViewModel>();
                var response = await httpClient.GetAsync("http://localhost:65386/Employee");
                string apiResponse = await response.Content.ReadAsStringAsync();
                employeeList = JsonConvert.DeserializeObject<List<ViewModel>>(apiResponse);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string remove)
        {
            List<ViewModel> employeeList = new List<ViewModel>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync($"http://localhost:65386/Employee?removeEmployee={remove}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        employeeList = JsonConvert.DeserializeObject<List<ViewModel>>(apiResponse);
                        // do this on the front end return Ok("removed: " + remove);
                        //return View(apiResponse);
                    }
                    //return View(apiResponse);
                }
                //return View(employeeList);
                //return BadRequest("Something went wrong could not find employee");
                //return RedirectToAction("Index");

            }
            return (IActionResult)employeeList;
            //return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            ViewModel employee = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:65386/Employee");
                //HTTP GET
                {


                }
            }
            return View(employee);
            //return Ok();
        }

        //update employees information method
        //delete employee method
    }
}

