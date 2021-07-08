using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static System.String;

namespace Chiwchi.Console
{
    internal static class ConsoleTable
    {
        public static TypeTable TypeTable { get; set; }

        public static string[,] GetTableStructure<TSource>(IEnumerable<TSource> dataList)
        {
            var list = dataList.ToList();
            var columnHeaders = GetClassProperties(list.FirstOrDefault());

            var rowCount = list.Count + 1;
            var columnCount = list.Count - 1;

            var arrayStrings = new string[rowCount, columnCount];

            for (var colIndex = 0; colIndex < arrayStrings.GetLength(1); colIndex++)
                arrayStrings[0, colIndex] = columnHeaders[colIndex];

            var rowPosition = 1;
            var colPosition = 0;

            foreach (var header in columnHeaders)
            {
                foreach (var value in list)
                {
                    arrayStrings[rowPosition, colPosition] = GetPropValue(value, header).ToString();
                    rowPosition++;
                }

                colPosition++;
                rowPosition = 1;
            }

            return arrayStrings;
        }

        public static string Draw(string[,] tableStructure)
        {
            var separatorTwo = TypeTable == TypeTable.Minimal ? Empty : "|";
            var separatorOne = TypeTable == TypeTable.Minimal ? Empty : "/";
            const string separatorThree = "+";

            var maxColumnsWidth = GetMaxColumnsWidth(tableStructure);

            var splitterLength = TypeTable == TypeTable.Minimal
                ? maxColumnsWidth.Sum(width => width + 2)
                : maxColumnsWidth.Sum(width => width + 3) - 1;

            var headerSpliter = new string('-', splitterLength);

            var format = new StringBuilder();

            if (TypeTable == TypeTable.Alternative)
            {
                format.AppendFormat(" {0}{1}{0} ", separatorOne, headerSpliter);
                format.AppendLine();
            }

            for (var rowIndex = 0; rowIndex < tableStructure.GetLength(0); rowIndex++)
            {
                for (var colIndex = 0; colIndex < tableStructure.GetLength(1); colIndex++)
                {
                    var cell = tableStructure[rowIndex, colIndex];
                    cell = cell.PadRight(maxColumnsWidth[colIndex]);
                    format.Append($" {separatorTwo} ");
                    format.Append(cell);
                }

                format.Append($" {separatorTwo} ");
                format.AppendLine();

                if (rowIndex == 0)
                {
                    format.AppendFormat(" {0}{1}{0} ", separatorOne, headerSpliter);
                    format.AppendLine();
                }
                else if (TypeTable == TypeTable.Alternative)
                {
                    format.AppendFormat(" {0}{1}{0} ", separatorThree, headerSpliter);
                    format.AppendLine();
                }
            }

            return format.ToString();
        }

        private static int[] GetMaxColumnsWidth(string[,] tableStructure)
        {
            var maxColumnsWidth = new int[tableStructure.GetLength(1)];
            for (var colIndex = 0; colIndex < tableStructure.GetLength(1); colIndex++)
            {
                for (var rowIndex = 0; rowIndex < tableStructure.GetLength(0); rowIndex++)
                {
                    var newLength = Length(tableStructure[rowIndex, colIndex]);
                    var oldLength = maxColumnsWidth[colIndex];

                    if (newLength > oldLength) maxColumnsWidth[colIndex] = newLength;
                }
            }

            return maxColumnsWidth;
        }

        private static int Length(string value)
        {
            if (value.Equals(Empty))
                return 0;

            var length = 0;
            var data = new ASCIIEncoding();
            var bytes = data.GetBytes(value);

            foreach (var item in bytes)
            {
                if (item == 63)
                    length++;

                length++;
            }

            return length;
        }

        private static object GetPropValue(object source, string propertyName)
        {
            var property = source.GetType().GetRuntimeProperties().FirstOrDefault(p =>
                string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));

            return property?.GetValue(source);
        }

        private static List<string> GetClassProperties(object list)
        {
            if (list == null) return new List<string>();

            var type = list.GetType();
            var property = type.GetProperties();

            return property.Select(props => props.Name).ToList();
        }
    }
}