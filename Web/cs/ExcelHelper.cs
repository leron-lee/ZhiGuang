using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Reflection;
public class ExcelHelper
{
    public static void DataTabletoExcel(System.Data.DataTable tmpDataTable, string strFileName)
    {
        if (tmpDataTable != null)
        {
            int rowNum = tmpDataTable.Rows.Count;
            int columnNum = tmpDataTable.Columns.Count;
            int rowIndex = 1;
            int columnIndex = 0;
            Application xlApp = new Application();
            xlApp.DefaultFilePath = "";
            xlApp.DisplayAlerts = true;
            xlApp.SheetsInNewWorkbook = 1;
            Workbook xlBook = xlApp.Workbooks.Add(true);
            foreach (DataColumn dc in tmpDataTable.Columns)
            {
                columnIndex++;
                xlApp.Cells[rowIndex, columnIndex] = dc.ColumnName;
            }
            for (int i = 0; i < rowNum; i++)
            {
                rowIndex++;
                columnIndex = 0;
                for (int j = 0; j < columnNum; j++)
                {
                    columnIndex++;
                    xlApp.Cells[rowIndex, columnIndex] = tmpDataTable.Rows[i][j].ToString();
                }
            }
            xlBook.SaveCopyAs(strFileName);
            xlBook.Close(System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
        }
    }
}
