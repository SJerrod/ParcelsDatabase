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
  }
}