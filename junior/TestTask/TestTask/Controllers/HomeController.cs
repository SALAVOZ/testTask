using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
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
        private string pathUser = @"C:\testTask\junior\TestTask\TestTask.Data\Users.json";
        private string pathUserTypes = @"C:\testTask\junior\TestTask\TestTask.Data\UserTypes.json";
        public HomeController(ILogger<HomeController> logger, IDataJsonReader dataReader)
        {
            _logger = logger;
            _dataReader = dataReader;
        }

        public IActionResult Index(int typeId = 0, string login = "", string password = "", string name = "")
        {
            var data = _dataReader.GetFiltredUsersByTypeId(typeId, login, password, name);
            ViewData["userTypes"] = _dataReader.ReadFromJson<UserTypeModel>(pathUserTypes);
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
            var userModelViews = new List<UserModelView>();
            foreach(var model in models)
            {
                userModelViews.Add(new UserModelView(
                    model.id,
                    model.login,
                    model.password,
                    model.name,
                    _dataReader.GetUserTypeById(model.type_id),
                    model.last_visit_date
                                                ));
            }
            return userModelViews.ToArray();
        }

        public string[] GetUserTypesString()
        {
            return _dataReader.getUserTypesString();
            
        }
    }
}
