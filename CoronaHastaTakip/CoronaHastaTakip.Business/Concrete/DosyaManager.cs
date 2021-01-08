using FastMember;
using CoronaHastaTakip.Business.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace CoronaHastaTakip.Business.Concrete
{
    public class DosyaManager : IDosyaService
    {
        public byte[] AktarExcel<T>(List<T> list)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new ExcelPackage();

            var excelBlank = excelPackage.Workbook.Worksheets.Add("Calisma1");

            excelBlank.Cells["A1"].LoadFromCollection(list, true, OfficeOpenXml.Table.TableStyles.Light15);

            return excelPackage.GetAsByteArray();
        }

        public string AktarPdf<T>(List<T> list)
        {
            DataTable dataTable = new DataTable();
            dataTable.Load(ObjectReader.Create(list));

            var fileName = Guid.NewGuid() + ".pdf";
            var returnPath = "/documents/" + fileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents/" + fileName);
            var stream = new FileStream(path, FileMode.Create);

            string arialTtf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

            BaseFont baseFont = BaseFont.CreateFont(arialTtf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            Font font = new Font(baseFont, 12, Font.NORMAL);

            Document document = new Document(PageSize.A4, 25f, 25f, 25f, 25f);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfpTable = new PdfPTable(dataTable.Columns.Count);

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                pdfpTable.AddCell(new Phrase(dataTable.Columns[i].ColumnName,font));
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    pdfpTable.AddCell(new Phrase(dataTable.Rows[i][j].ToString(),font));
                }
            }

            document.Add(pdfpTable);
            document.Close();

            return returnPath;
        }
    }
}
