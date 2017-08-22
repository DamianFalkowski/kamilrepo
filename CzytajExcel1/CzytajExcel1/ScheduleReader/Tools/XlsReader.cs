using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleDataModel.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace ScheduleReader.Tools
{
    public class XlsReader
    {
        //singleton
        private static XlsReader instance = null;
        public static XlsReader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new XlsReader();
                }
                return instance;
            }
        }
        private XlsReader() { }

        //methods
        public Schedule GetSchedule(string path)
        {
            string[,] excel = this.getValuesFromExcel(path);
            var plan = new Schedule();
            plan.Name = excel[0, 0];
            int bufor_wiersz = excel.GetLength(0);
            int bufor_kolumna = excel.GetLength(1);

            var dzien = new ScheduleDayOfWeek();
            var grupa = new StudentGroup();

            for (int wiersz = 1; wiersz < bufor_wiersz; wiersz++)
            {
                Subject aktualnyPrzedmiot = new Subject();

                for (int kolumna = 0; kolumna < bufor_kolumna; kolumna++)
                {

                    if (kolumna == 0 && String.IsNullOrEmpty(excel[wiersz, kolumna]))
                    {
                        if (dzien.Day != SubjectTimeResolver.Instance.GetDayOfWeekFromString(excel[wiersz, kolumna]))
                        {
                            // jest nowy dzien
                            dzien.Day = SubjectTimeResolver.Instance.GetDayOfWeekFromString(excel[wiersz+1, kolumna]);
                            plan.DaysOfWeek.Add(dzien);
                            dzien = new ScheduleDayOfWeek();
                        }
                        dzien.Day = SubjectTimeResolver.Instance.GetDayOfWeekFromString(excel[wiersz, kolumna]);
                    }
                    else if (kolumna == 1 && String.IsNullOrEmpty(excel[wiersz, kolumna]))
                    {
                        grupa.Name = excel[wiersz, kolumna];
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(excel[wiersz, kolumna]))// jest coś w komórce
                        {
                            if (excel[wiersz, kolumna] != aktualnyPrzedmiot.Name)
                            {
                                // zaczyna sie nowy przedmiot i konczy stary lub po prostu zaczyna sie przedmiot
                                if (!String.IsNullOrEmpty(aktualnyPrzedmiot.Name))
                                {
                                    aktualnyPrzedmiot.TimeEnds = Tools.SubjectTimeResolver.Instance.GetMinutesFromCell(kolumna);
                                    grupa.Subjects.Add(aktualnyPrzedmiot);
                                }
                                aktualnyPrzedmiot = new Subject();
                                aktualnyPrzedmiot.TimeStarts = Tools.SubjectTimeResolver.Instance.GetMinutesFromCell(kolumna);
                                aktualnyPrzedmiot.Name = excel[wiersz, kolumna];
                            }
                            else
                            {
                                // trwa stary
                            }
                        }
                        else // komórka jest pusta
                        {
                            if (!String.IsNullOrEmpty(aktualnyPrzedmiot.Name)) // aktualny przedmiot nie jest pusty
                            {
                                // skonczyl sie aktualny przedmiot
                                aktualnyPrzedmiot.TimeEnds = Tools.SubjectTimeResolver.Instance.GetMinutesFromCell(kolumna);
                                grupa.Subjects.Add(aktualnyPrzedmiot);
                                aktualnyPrzedmiot = new Subject();
                            }
                        }
                    }
                }
                dzien.StudentGroups.Add(grupa);
                grupa = new StudentGroup();
            }
            return plan;
        }

        private string[,] getValuesFromExcel(string pathToExcel)
        {
            var xlApp = new Excel.Application();
            var xlWorkbook = xlApp.Workbooks.Open(pathToExcel);
            var xlWorksheet = xlWorkbook.Sheets[1];
            var xlRange = xlWorksheet.UsedRange;

            var rowCount = xlRange.Rows.Count;
            var colCount = xlRange.Columns.Count;
            var excelValues = new string[rowCount, colCount];

            try
            {
                for (int row = 1; row <= rowCount; row++)
                for (int column = 1; column <= colCount; column++)
                    excelValues[row - 1, column - 1] = getCellValue(xlRange.Cells[row, column]);
            }
            finally
            {
                xlRange = null;
                xlWorksheet = null;
                xlWorkbook.Close();
                xlApp.Quit();
            }

            return excelValues;
        }

        private string getCellValue(Excel.Range cell)
        {
            if (cell?.Value2 != null)
                return cell?.Value2.ToString();

            var cellsRange = cell.MergeArea.Cells.Value2;
            if (cellsRange != null)
                foreach (var cellValue in cellsRange)
                    if (cellValue is string)
                        return cellValue;

            return String.Empty;
        }
    }
}
