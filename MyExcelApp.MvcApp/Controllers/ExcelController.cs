using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;
using System.Text.Json;
using MyExcelApp.MvcApp.Data;
using MyExcelApp.MvcApp.Models;

namespace MyExcelApp.MvcApp.Controllers;

public class ExcelController : Controller
{
    private readonly ApplicationDbContext _context;

    public ExcelController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Action to display the upload form
    public IActionResult Upload()
    {
        return View();
    }

    // Controllers/ExcelController.cs
    [HttpPost]
    public IActionResult Upload(IFormFile file, string fileName)
    {
        if (file == null || file.Length == 0)
        {
            TempData["Message"] = "File is not selected";
            return RedirectToAction("Upload");
        }

        if (string.IsNullOrEmpty(fileName))
        {
            TempData["Message"] = "File name is required";
            return RedirectToAction("Upload");
        }

        using (var stream = new MemoryStream())
        {
            file.CopyTo(stream);
            using (var workbook = new XLWorkbook(stream))
            {
                foreach (var worksheet in workbook.Worksheets)
                {
                    var data = worksheet.RowsUsed().Select(row => row.CellsUsed().Select(cell => cell.Value.ToString()).ToList()).ToList();
                    var jsonData = JsonSerializer.Serialize(data);

                    var excelData = new ExcelData
                    {
                        SheetName = worksheet.Name,
                        Data = jsonData,
                        FileName = fileName
                    };

                    _context.ExcelData.Add(excelData);
                }
                _context.SaveChanges();
            }
        }

        TempData["Message"] = "File uploaded and stored successfully";
        return RedirectToAction("Index");
    }

    // Action to display the list of uploaded Excel files
    public IActionResult Index()
    {
        var excelFiles = _context.ExcelData.ToList();
        return View(excelFiles);
    }

    // Controllers/ExcelController.cs
    public IActionResult Export(int id)
    {
        var excelData = _context.ExcelData.FirstOrDefault(e => e.Id == id);
        if (excelData == null)
        {
            TempData["Message"] = "Data not found";
            return RedirectToAction("Index");
        }

        var data = JsonSerializer.Deserialize<List<List<string>>>(excelData.Data);

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add(excelData.SheetName);

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Count; j++)
                {
                    worksheet.Cell(i + 1, j + 1).Value = data[i][j];
                }
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                TempData["Message"] = "File exported successfully";
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{excelData.FileName}.xlsx");
            }
        }
    }
}
