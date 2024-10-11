namespace MyExcelApp.MvcApp.Models;

// Models/ExcelData.cs
public class ExcelData
{
    public int Id { get; set; }
    public string? SheetName { get; set; }
    public string? Data { get; set; } // Store the data as JSON
    public string? FileName { get; set; } // Store the file name
}
