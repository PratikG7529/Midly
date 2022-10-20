using Midly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Midly.ViewModels;

namespace Midly.Controllers
{
    public class CustomersController : Controller
    {
        ApplicationDbContext _applicationDbContext;

        public CustomersController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _applicationDbContext.Dispose();

        }
        // GET: Customers
        [Authorize]
        public ActionResult Details()
        {
            //var customer = new List<Customer>()
            //{
            //    new Customer{ Id =1,Name="Sam "},
            //    new Customer{ Id = 2,Name = "Minky"}
            //};


            //Using datatables to extract data
            //var customer = _applicationDbContext.Customers.Include(c => c.MembershipType).ToList();
            return View();
        }
        public ActionResult GetDetails(int id)
        {
            var customer = _applicationDbContext.Customers.Include(c => c.MembershipType).FirstOrDefault(x => x.Id == id);
            return View(customer);
        }
        public ActionResult NewCustomer()
        {
            var membershipType = _applicationDbContext.MembershipTypes.ToList();
            /*
             * Created a viewmodel because we have to pass membershiptype along with customer model
             * So created a viewModel and passed the membershiptype along with customers
             */
            var newCustomerViewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipType = membershipType
            };

            return View("CustomerFrom", newCustomerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //Used to disable attackers to perform any melicious action
        public ActionResult CustomerFrom(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var membershipType = _applicationDbContext.MembershipTypes.ToList();
                var newCustomerViewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = membershipType
                };

                return View("CustomerFrom", newCustomerViewModel);
            }
            if (customer.Id == 0)
            {
                _applicationDbContext.Customers.Add(customer);
            }
            else
            {
                var updateCustomer = _applicationDbContext.Customers.Single(x => x.Id == customer.Id);
                updateCustomer.Name = customer.Name;
                updateCustomer.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                updateCustomer.Birthdate = customer.Birthdate;
            }
            
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Details", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _applicationDbContext.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                var customerViewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = _applicationDbContext.MembershipTypes
                };
                return View("CustomerFrom", customerViewModel);
            }

                
        }


    }
}