using System;
using System.IO;
using Q4CsvParser.Contracts;
using Q4CsvParser.Domain;

namespace Q4CsvParser.Web.Core
{
    /// <summary>
    /// This file must be unit tested.
    /// </summary>
    public class ParsingService : IParsingService
    {
        /// <summary>
        /// Accepts a string with the contents of the csv file in it and should return a parsed csv file.
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="containsHeader"></param>
        /// <returns></returns>
        public CsvTable ParseCsv(string fileContent, bool containsHeader)
        {
            CsvTable csvTable = new CsvTable();
            fileContent = fileContent.TrimEnd();
            string[] rowSeparators = new string[] { "\r\n" , "\n","\r" };
            string[] rows = fileContent.Split(rowSeparators, StringSplitOptions.None);
            if (rows.Length > 0)
            {
                if (containsHeader)
                {
                    CsvRow headerRow = GenerateRow(rows[0]);
                    csvTable.HeaderRow = headerRow;
                    if (rows.Length > 1)
                    {
                        for (int i = 1; i < rows.Length; i++)
                        {
                            CsvRow csvRow = GenerateRow(rows[i]);
                            csvTable.Rows.Add(csvRow);
                        }
                    }
                }
                else
                {
                    foreach (string row in rows)
                    {
                        CsvRow csvRow = GenerateRow(row);
                        csvTable.Rows.Add(csvRow);
                    }
                }
            }
            return csvTable;
        }

        private CsvRow GenerateRow(string rowValue)
        {
            rowValue = rowValue.TrimEnd();
            CsvRow csvRow = new CsvRow
            {
                Columns = new System.Collections.Generic.List<CsvColumn>()
            };
            foreach (string column in rowValue.Split(','))
            {
                csvRow.Columns.Add(new CsvColumn(column));
            }

            return csvRow;
        }
    }
}
