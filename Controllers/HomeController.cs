using Microsoft.AspNetCore.Mvc;
using Parcels.Models;

namespace Parcels.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/cost")]
    public ActionResult Cost()
    {
      return View();
    }

    [HttpPost("/cost")]
    public ActionResult Cost(int length, int height, int width, int weight)
    {
      Package newPackage = new Package(length, height, width, weight);
      newPackage.GetVolume();
      newPackage.CostToShip();
      
      return View (newPackage); 
    }

  }
}