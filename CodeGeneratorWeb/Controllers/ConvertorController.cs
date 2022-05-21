using CodeGeneratorWeb.Models;
using LanguageConvertor.Core;
using Microsoft.AspNetCore.Mvc;

namespace CodeGeneratorWeb.Controllers;

[Route("convert")]
public class ConvertorController : Controller
{
    private readonly ILogger<ConvertorController> _logger;

    public ConvertorController(ILogger<ConvertorController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet, HttpPost]
    public async Task<IActionResult> Convert()
    {
        if (!Request.Method.Equals("POST")) return View();
        
        // Get values
        Request.Form.TryGetValue("Language", out var language);

        var parsedLanguage = Enum.Parse<ConvertibleLanguage>(language);

        var formFiles = Request.Form.Files;
        foreach (var formFile in formFiles)
        {
            var filePath = Path.GetFullPath(@$"Files\{formFile.FileName}");
            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }
        
            // Convert data
            var convertor = new Convertor(filePath, parsedLanguage);
            const string exportPath = @"C:\dev\CSharp\CodeGenerator\CodeGeneratorWeb\Files";
            convertor.NewFile(exportPath);

            // Delete old file
            System.IO.File.Delete(filePath);
        }

        return RedirectToAction("ConvertedFiles", "Home");
    }
}