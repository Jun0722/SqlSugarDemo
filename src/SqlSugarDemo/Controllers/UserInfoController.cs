using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SqlSugarDemo.IRepository;
using SqlSugarDemo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SqlSugarDemo.Controllers
{
    public class UserInfoController : Controller
    {
        private IUserInfoRepository _userInfoRepository;
        public UserInfoController(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            List<UserInfo> userInfos = _userInfoRepository.GetAll();
            ViewData.Model = userInfos;

            return View();
        }
    }
}
