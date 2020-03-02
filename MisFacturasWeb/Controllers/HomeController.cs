using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MisFacturasWeb.Models;
using MisFacturasWeb.TokenProvider;
using SecurityBussines.Iuser;

namespace MisFacturasWeb.Controllers
{
    public class HomeController: BaseController //: BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private static Isecurity _security;

        //    private  RequestHandler _requestHandler; , IHttpContextAccessor httpContextAcc) : base(httpContextAcc
        public HomeController(ILogger<HomeController> logger, Isecurity security)
        {
            _security = security;
            _logger = logger;
        }

        //public HomeController(RequestHandler requestHandler)
        //{
        //    this._requestHandler = requestHandler;
        //}
        [JwtAuthentication]
        public IActionResult Index()
        {
            var context = HttpContext;
            //HttpContextAccessor.HttpContext.Request.Form.FirstOrDefault().Value.ToString()
            // values from ajax load
            // please do not delete 



            //var _user = AppContextCustom.Current.User;
            //var _Items = AppContextCustom.Current.Items;
            return View();
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


//HttpContextAccessor.HttpContext.Request.Form.FirstOrDefault().Value.ToString()
// values from ajax load
// please do not delete 

/*
 
     $(document).ready(function(){
    $("button").click(function(){
        $("#boxShow").load('https://localhost:44309/Home', // url 
                  { name: 'bill' },    // data 
                  function(data, status, jqXGR) {  // callback function 
                            alert('data loaded')
                    });
    });
});


     */
