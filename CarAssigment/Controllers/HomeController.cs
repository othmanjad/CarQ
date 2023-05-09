using CarAssigment.Business;
using CarAssigment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarAssigment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService _carService;

        public HomeController(ILogger<HomeController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
           
            return View();
        }

        public async Task<IActionResult> GetMakeList()
        {
            var data = await _carService.GetMakeList();
            return Json(data.Results.Select(x=>new {Id=x.Make_ID,Text=x.Make_Name }));
        }
        public async Task<IActionResult> GetVehicleTypesByMakeId(int Id)
        {
            var data = await _carService.GetVehicleTypesByMakeId(Id);
            return Json(data.Results.Select(x => new { Id = x.VehicleTypeId, Text = x.VehicleTypeName }));
        }
        [HttpPost]
        public async Task<IActionResult> GetModelsforMake(ModelsforMakeRequest request)
        {
            var data = await _carService.GetModelsforMake(request);
            return Json(new { data= data.Results , recordsTotal=data.Count, recordsFiltered = data.Count , draw= 1, });
        }
    }
}
