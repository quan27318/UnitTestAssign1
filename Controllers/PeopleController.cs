using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCAssign.Models;
using MVCAssign.Service;

namespace MVCAssign.Controllers;

public class PeopleController : Controller
{
    private readonly ILogger<PeopleController> _logger;
    private IPeople _iPeople;
    public PeopleController(ILogger<PeopleController> logger, IPeople iPeople)
    {
        _logger = logger;
        _iPeople = iPeople;
    }

    public IActionResult Index()
    {
         return View(_iPeople.GetAll());
    }
    
    public IActionResult Detail(int id)
    {
        var personDetail = _iPeople.GetAll().Where(x => x.Id == id).FirstOrDefault();
        return View(personDetail);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(PersonModel model)
    {
        _iPeople.Create(model);
        return RedirectToAction("Index");
    }
    public IActionResult Update(int id )
    {
        var person = _iPeople.GetAll().Where(x=>x.Id==id).FirstOrDefault();
        return View(person);
    }
    [HttpPost]
    public IActionResult Update(PersonModel person)
    {
        _iPeople.Update(person);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {  
        var p = _iPeople.Delete(id);
       return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
