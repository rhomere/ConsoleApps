using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelLibrary.SpreadSheet;
using ConsoleApps.Models;
using System.IO;

namespace ConsoleApps.SpreadSheet
{
    public class SpreadsheetService
    {
        public SpreadsheetService()
        {

        }

        public void DoStuff()
        {
            var records = GetPartners();
            var wb = CreateReportAsWorkbook(records);
            wb.Save($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\report.xls");
        }

        public List<Partner> GetPartners()
        {
            return new List<Partner>
            {
                new Partner{ Order = 1, Name = "Iris B...", AgeMet = 19, Background = "Cuban", RateOnScale = "7/10"},
                new Partner{ Order = 2, Name = "Manina Salem Juedy", AgeMet = 19, Background = "Haitian/American", RateOnScale = "7/10"},
                new Partner{ Order = 3, Name = "Alena? (Oakland Chick from USA/wanted to be a stripper)", AgeMet = 19, Background = "Black/Puerto-Rican", RateOnScale = "10/10"},
                new Partner{ Order = 4, Name = "Rose Darbouze", AgeMet = 20, Background = "Haitian", RateOnScale = "7/10"},
                new Partner{ Order = 5, Name = "Yuridia Geraldine Mendoza", AgeMet = 20, Background = "Mexican", RateOnScale = "10/10"},
                new Partner{ Order = 6, Name = "Dayva Tutein Henry", AgeMet = 21, Background = "Black/American", RateOnScale = "8/10"},
                new Partner{ Order = 7, Name = "Jessica Maria Barrios", AgeMet = 24, Background = "Cuban/Dominican/Puerto-Rican", RateOnScale = "10/10"},
                new Partner{ Order = 8, Name = "Tabresha ...", AgeMet = 25, Background = "Black/American", RateOnScale = "9/10"},
                new Partner{ Order = 9, Name = "Brazilian from IHG", AgeMet = 25, Background = "Brazilian", RateOnScale = "10/10"},
                new Partner{ Order = 10, Name = "Girl from Tabresha's Dorm", AgeMet = 26, Background = "Black/American", RateOnScale = "7/10"},
                new Partner{ Order = 11, Name = "Cali girl, Carrie look-alike", AgeMet = 26, Background = "White/American", RateOnScale = "10/10"},
                new Partner{ Order = 12, Name = "Flight Attendant @ El Patio", AgeMet = 26, Background = "Mixed/European", RateOnScale = "10/10"},
                new Partner{ Order = 13, Name = "Gabriela Russel", AgeMet = 26, Background = "Hispanic", RateOnScale = "10/10"},
                new Partner{ Order = 14, Name = "Dagmar Day", AgeMet = 26, Background = "Haitian", RateOnScale = "10/10"},
                new Partner{ Order = 15, Name = "Eleese Sinnot", AgeMet = 19, Background = "Irish/Italian", RateOnScale = "10/10"}
            };
        }

        public byte[] CreateReportInBytes(List<Partner> partners)
        {
            Workbook wb = new Workbook();
            Worksheet ws = new Worksheet("Report");
            ws.Cells[0, 1] = new Cell("Name");
            ws.Cells[0, 2] = new Cell("Age met");
            ws.Cells[0, 3] = new Cell("Background");
            ws.Cells[0, 4] = new Cell("Rate");

            var row = 1;
            foreach (var r in partners)
            {
                ws.Cells[row, 1] = new Cell(r.Name);
                ws.Cells[row, 2] = new Cell(r.AgeMet);
                ws.Cells[row, 3] = new Cell(r.Background);
                ws.Cells[row, 4] = new Cell(r.RateOnScale);
                row++;
            }

            for (int i = row; i < 110; i++)
                ws.Cells[i, 0] = new Cell("");

            wb.Worksheets.Add(ws);

            using (MemoryStream m = new MemoryStream())
            {
                wb.SaveToStream(m);

                int read;
                m.Seek(0, SeekOrigin.Begin);
                byte[] buffer = new byte[(int)m.Length];
                while ((read = m.Read(buffer, 0, buffer.Length)) > 0)
                {
                    m.Write(buffer, 0, read);
                }
                return m.ToArray();
            }
        }
        public Workbook CreateReportAsWorkbook(List<Partner> partners)
        {
            Workbook wb = new Workbook();
            Worksheet ws = new Worksheet("Report");
            ws.Cells[0, 1] = new Cell("Name");
            ws.Cells[0, 2] = new Cell("Age met");
            ws.Cells[0, 3] = new Cell("Background");
            ws.Cells[0, 4] = new Cell("Rate");

            var row = 1;
            foreach (var r in partners)
            {
                ws.Cells[row, 1] = new Cell(r.Name);
                ws.Cells[row, 2] = new Cell(r.AgeMet);
                ws.Cells[row, 3] = new Cell(r.Background);
                ws.Cells[row, 4] = new Cell(r.RateOnScale);
                row++;
            }

            for (int i = row; i < 110; i++)
                ws.Cells[i, 0] = new Cell("");

            wb.Worksheets.Add(ws);

            return wb;
        }
    }
}
