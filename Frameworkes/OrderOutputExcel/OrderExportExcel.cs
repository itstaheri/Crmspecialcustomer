using ClosedXML.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frameworks;

namespace Frameworkes.OrderOutputExcel
{
    public class OrderExportExcel
    {
        public virtual async Task<byte[]> GenerateExcel(List<OrderDetailOutput> orderDetails)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("order");
            
          
            var currentrow = 1;
            worksheet.Cell(currentrow, 1).Value = "نام جنس";
            worksheet.Cell(currentrow, 2).Value = "تعداد کور موجود";
            worksheet.Cell(currentrow, 3).Value = "واحد";
            worksheet.Cell(currentrow, 4).Value = "تعداد کور سهم طرف قرارداد";
            worksheet.Cell(currentrow, 5).Value = "مقدار";
            worksheet.Cell(currentrow, 6).Value = "قیمت جنس";
            worksheet.Cell(currentrow, 7).Value = "قیمت کار اجرایی";
            worksheet.Cell(currentrow, 8).Value = "سهم طرف قرارداد";
            worksheet.Cell(currentrow, 9).Value = "قیمت کل";
            worksheet.Cell(currentrow, 10).Value = "قیمت کل بعد از تخفیف";
            for (int i = 1; i <= 10; i++)
            {
                worksheet.Cell(1, i).Style.Fill.SetBackgroundColor(XLColor.Cyan);

            }
            foreach (var item in orderDetails)
            {
                currentrow++;
                worksheet.Cell(currentrow, 1).Value = item.ServiceName;
                worksheet.Cell(currentrow, 2).Value = item.CoreCount;
                worksheet.Cell(currentrow, 3).Value = item.UnitOfMaterial;
                worksheet.Cell(currentrow, 4).Value = item.CoreCountSide;
                worksheet.Cell(currentrow, 5).Value = item.Value;
                worksheet.Cell(currentrow, 6).Value = item.MaterialPrice.ToMoney();
                worksheet.Cell(currentrow, 7).Value = item.SalaryPrice.ToMoney();
                worksheet.Cell(currentrow, 8).Value = item.CustomerShare;
                worksheet.Cell(currentrow, 9).Value = item.TotalPrice.ToMoney();
                worksheet.Cell(currentrow, 10).Value = item.PayAmount.ToMoney();
              
            }


            //make columns text Righ to left
            worksheet.SetRightToLeft(worksheet.RightToLeft);

            //create and stream excel
            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();
            return content;


        }
    }
}
