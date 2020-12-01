﻿using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLib
{
    /// <summary>
    /// https://www.youtube.com/watch?v=Dpvi8mf3qMs&list=PL6tu16kXT9PqKSouJUV6sRVgmcKs-VCqo&index=15&t=221s
    /// </summary>
    public class Utilities
    {

        static List<TableDatacollection> _tableDatacollections = new List<TableDatacollection>();

        static public void ReadTable(IWebElement table)
        {
            var columns = table.FindElements(By.TagName("th"));
            Console.WriteLine(columns);
            var rows = table.FindElements(By.TagName("tr"));

            int rowIndex = 0;
            //var colnam = columns[colIndex];
            foreach (var row in rows)
            {
                int colIndex = 0;

                var colDatas = row.FindElements(By.TagName("td"));

                foreach (var colValue in colDatas)
                {
                    _tableDatacollections.Add(new TableDatacollection
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[colIndex].Text != "" ?
                                     columns[colIndex].Text : colIndex.ToString(),
                        ColumnValue = colValue.Text,
                        ColumnSpecialValues = colValue.Text != "" ? null :
                                              colValue.FindElements(By.TagName("input"))
                    });

                    colIndex++;
                }
                rowIndex++;
            }


        }

        static public string ReadCell(string columnName, int rowNumber)
        {
            var data = (from e in _tableDatacollections
                        where e.ColumnName == columnName && e.RowNumber == rowNumber
                        select e.ColumnValue).SingleOrDefault();
            return data;
        }

        public static void PerformActionOnCell(string columnIndex, string refColumnName, string refColumnValue, string controlToOperate = null)
        {

            foreach (int rowNumber in GetDynamicRowNumber(refColumnName, refColumnValue))
            {
                var cell = (from e in _tableDatacollections
                            where e.ColumnName == columnIndex && e.RowNumber == rowNumber
                            select e.ColumnSpecialValues).SingleOrDefault();

                if (controlToOperate != null && cell != null)
                {
                    var returnedControl = (from c in cell
                                           where c.GetAttribute("value") == controlToOperate
                                           select c).SingleOrDefault();
                    returnedControl?.Click();
                }
                else
                {
                    cell?.First().Click();
                }
            }

            //Need to operate on those controls

        }


        private static IEnumerable GetDynamicRowNumber(string columnName, string columnValue)
        {
            foreach (var table in _tableDatacollections)
            {
                if (table.ColumnName == columnName && table.ColumnValue == columnValue)
                {
                    yield return table.RowNumber;
                }
            }
        }

        public class TableDatacollection
        {
            public int RowNumber { get; set; }
            public string ColumnName { get; set; }
            public string ColumnValue { get; set; }

            public IEnumerable<IWebElement> ColumnSpecialValues { get; set; }
        }
    }
}
