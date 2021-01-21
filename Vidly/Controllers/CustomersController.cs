using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext context;

        public CustomersController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        [HttpGet]
        public ActionResult Index()
        {
            // Commented out: We get the data using DataTable and the Customers API

            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //return View(customers);

            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var customer = context.Customers
                .Where(c => c.Id == id)
                .Include(c => c.MembershipType)
                .FirstOrDefault();

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [HttpGet]
        public ActionResult New()
        {
            var membershipTypes = context.MembershipTypes.ToList();
            var viewModel = new CustomerFormVm() { MembershipTypes = membershipTypes };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var model = new CustomerFormVm()
                {
                    Customer = customer,
                    MembershipTypes = context.MembershipTypes.ToList()
                };

                return View(model);
            }

            context.Customers.Add(customer);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = context.Customers.Where(c => c.Id == id).FirstOrDefault();

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormVm()
            {
                Customer = customer,
                MembershipTypes = context.MembershipTypes.ToList()
            };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var model = new CustomerFormVm()
                {
                    Customer = customer,
                    MembershipTypes = context.MembershipTypes.ToList()
                };

                return View(model);
            }
            
            var dbCustomer = context.Customers.Where(c => c.Id == customer.Id).Single();

            dbCustomer.Name = customer.Name;
            dbCustomer.Birthdate = customer.Birthdate;
            dbCustomer.MembershipTypeId = customer.MembershipTypeId;
            dbCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;


            context.SaveChanges();     

            return RedirectToAction("Index");
        }
    }
}