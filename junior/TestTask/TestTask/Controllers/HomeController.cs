using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TestTask.Data.DataModels;
using TestTask.Data.Interfaces;
using TestTask.Models;
using TestTask.Models.HomePageModels;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataJsonReader _dataReader;
        public HomeController(ILogger<HomeController> logger, IDataJsonReader dataReader)
        {
            _logger = logger;
            _dataReader = dataReader;
        }

        public IActionResult Index()
        {
            var data = _dataReader.ReadUsersJson();
            return View(data);
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

        public UserModelView[] CreateUserModelViews(UserModel[] models)
        {
            foreach(var model in models)
            {
                yield return new UserModelView(
                    model.id,
                    model.login,
                    model.password,
                    model.name,
                    _dataReader.Get
                    model.last_visit_date
                                                );
            }
        }
    }
}
