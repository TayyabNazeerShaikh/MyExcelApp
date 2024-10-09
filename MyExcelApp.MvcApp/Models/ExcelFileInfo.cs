using System.ComponentModel.DataAnnotations;

namespace MyExcelApp.MvcApp.Models
{
    public class ExcelFileInfo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "File Name is required")]
        public string? FileName { get; set; }

        [Required(ErrorMessage = "Upload Date is required")]
        public DateTime UploadDate { get; set; }

        [Required(ErrorMessage = "Header Present status is required")]
        public bool IsHeaderPresent { get; set; }

        [Required(ErrorMessage = "Header Style is required")]
        public string? HeaderStyle { get; set; }

        // Add properties to hold information about styles for rows, columns, or individual cells
        public string? RowStyle { get; set; }
        public string? ColumnStyle { get; set; }
        public string? CellStyle { get; set; }

        // You can add additional properties as necessary for more details
    }
}
