using Microsoft.AspNetCore.Mvc;
using Parcels.Models;

namespace Parcels.Controllers
{
  public class PackageController : Controller
  {

    [HttpGet("/cost")]
    public ActionResult Cost()
    {
      return View();
    }

    [HttpPost("/cost")]
    public ActionResult Cost(int length, int height, int width, int weight, int id)
    {
      Package newPackage = new Package(length, height, width, weight, id);
      newPackage.GetVolume();
      newPackage.CostToShip();
      
      return View (newPackage); 
    }
  }
}