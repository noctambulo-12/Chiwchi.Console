using Pastel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chiwchi.Console
{
    public enum TypeTable
    {
        Default,
        Alternative,
        Minimal
    }

    public class Cli
    {
        public static void Log(string text, Color color, Color background)
        {
            System.Console.WriteLine(text.Pastel(color).PastelBg(background));
        }

        public static void Log(string text, Color color, string background)
        {
            System.Console.WriteLine(text.Pastel(color).PastelBg(background));
        }

        public static void Log(string text, string color, Color background)
        {
            System.Console.WriteLine(text.Pastel(color).PastelBg(background));
        }

        public static void Log(string text, string color, string background)
        {
            System.Console.WriteLine(text.Pastel(color).PastelBg(background));
        }

        public static void Success(string text)
        {
            System.Console.WriteLine(text.Pastel(Color.MediumSeaGreen));
        }

        public static void Info(string text)
        {
            System.Console.WriteLine(text.Pastel(Color.DodgerBlue));
        }

        public static void Error(string text)
        {
            System.Console.WriteLine(text.Pastel(Color.OrangeRed));
        }

        public static void Warning(string text)
        {
            System.Console.WriteLine(text.Pastel(Color.Orange));
        }

        public static void Table<TSource>(IEnumerable<TSource> data, TypeTable typeTable = TypeTable.Default)
        {
            ConsoleTable.TypeTable = typeTable;

            if (data == null) return;

            var tableStructure = ConsoleTable.GetTableStructure(data.ToList());
            var tableDrawing = ConsoleTable.Draw(tableStructure);

            System.Console.WriteLine(tableDrawing);
        }
    }
}