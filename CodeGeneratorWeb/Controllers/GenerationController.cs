using Microsoft.AspNetCore.Mvc;
using CodeGeneratorWeb.Models;

namespace CodeGeneratorWeb.Controllers;

[Route("generate")]
public class GenerationController : Controller
{
    [HttpGet, HttpPost]
    public IActionResult Generate()
    {
        if (!Request.Method.Equals("POST")) return View();
        
        return View();
    }
}