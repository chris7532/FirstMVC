using FirstMVC.DataAccess.Repository;
using FirstMVC.DataAccess.Repository.IRepository;
using FirstMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork db)
        {
            _logger = logger;
            _unitOfWork = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return View(products);
        }

        public IActionResult Details(int? productID)
        {
            Product product = _unitOfWork.Product.Get(u=>u.Id==productID, includeProperties: "Category");
            return View(product);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}