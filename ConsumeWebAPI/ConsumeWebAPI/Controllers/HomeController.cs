using Microsoft.AspNetCore.Mvc;
using ConsumeWebAPI.Models;
using Customer.Service;
using Customer.Service.Model;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using System.Reflection.Metadata;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System;

namespace ConsumeWebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerService _customerService;
        public HomeController(ILogger<HomeController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var apiResponse = await _customerService.GetAllCustomer();

                if (apiResponse != null)
                {
                    return View(apiResponse);
                }
                else
                {
                    _logger.LogError("API call failed with status code: Error");
                    return View(new List<Customer.Service.Model.Customer>());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"API call failed with exception: {ex.Message}");
                return View(new List<Customer.Service.Model.Customer>());
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer.Service.Model.Customer customer)
        {
            try
            {
                var createdCustomer = await _customerService.CreateCustomer(customer);

                if (createdCustomer != null)
                {
                    // Redirect to the index page or perform any other desired action
                    return RedirectToAction("Index");
                }
                else
                {
                    _logger.LogError("Failed to create customer.");
                    return View();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create customer: {ex.Message}");
                return View();
            }
        }

        [HttpGet, Route("edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var customer = await _customerService.GetCustomerById(id);

                if (customer != null)
                {
                    // Redirect to the index page or perform any other desired action
                    return View(customer);
                }
                else
                {
                    _logger.LogError("Failed to create customer.");
                    return View();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create customer: {ex.Message}");
                return View();
            }
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost, Route("edit/{id}")]
        public async Task<IActionResult> Edit (Customer.Service.Model.Customer updatedcustomer)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var customer = await _customerService.UpdateCustomer(updatedcustomer);

                    if (customer != null)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _logger.LogError("Failed to update customer.");
                        return View();
                    }
                }

                else
                {
                    _logger.LogError("Failed to create customer.");
                    return View();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create customer: {ex.Message}");
                return View();
            }
        }
        
        






    [HttpGet, Route("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                string deletedID = await _customerService.DeleteCustomer(id);

                if (deletedID != null)
                {
                    // Redirect to the index page or perform any other desired action
                    return RedirectToAction("Index");
                }
                else
                {
                    _logger.LogError("Failed to delete customer.");
                    return View();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to delete customer: {ex.Message}");
                return View();
            }
        }
        public IActionResult CreateITAddress()
        {
            // Return the view for IT address
            return View("CreateITAddress");
        }

        public IActionResult CreateGBAddress()
        {
            // Return the view for GB address
            return View("CreateGBAddress");
        }
    }
}
            
        

    


   








        