using Chiwchi.Console;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace TestConsoleTemporal
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine(string.Empty);
            Cli.Log(" ¡Hola Perú!", Color.Peru, Color.FromArgb(165, 229, 250));

            Console.WriteLine(string.Empty);
            Cli.Log(" ¡Hola Perú!", "#bada55", "#222");

            Console.WriteLine(string.Empty);
            Cli.Log(" ¡Hola Perú!", "007bff", Color.Black);

            Console.WriteLine(string.Empty);
            Cli.Success("¡Éxito!");

            Console.WriteLine(string.Empty);
            Cli.Warning("¡Advertencia! Algo no parece correcto.");

            Console.WriteLine(string.Empty);
            Cli.Error("¡Huy! Algo salió mal!");

            var Products = new List<Product>
            {
                new Product {ProductId = 1, ProductName = "Cassette", ProductImageUrl = "product_small_1.png", CreatedDate = DateTime.Now},
                new Product {ProductId = 2, ProductName = "VHS", ProductImageUrl = "product_small_2.png", CreatedDate = DateTime.Now},
                new Product {ProductId = 3, ProductName = "Walkman", ProductImageUrl = "product_small_3.png", CreatedDate = DateTime.Now},
                new Product {ProductId = 4, ProductName = "Discman", ProductImageUrl = "product_small_4.png", CreatedDate = DateTime.Now},
                new Product {ProductId = 5, ProductName = "Diskette", ProductImageUrl = "product_small_5.png", CreatedDate = DateTime.Now}
            };

            ConsoleSpinner spinner = new ConsoleSpinner();

            spinner.Start();
            Thread.Sleep(50000);
            spinner.Stop();

            Console.WriteLine(string.Empty);
            Cli.Success("TypeTable.Default");
            Console.WriteLine(string.Empty);

            Cli.Table(Products);

            Cli.Success("TypeTable.Minimal");
            Console.WriteLine(string.Empty);

            Cli.Table(Products, TypeTable.Minimal);

            Cli.Success("TypeTable.Alternative");
            Console.WriteLine(string.Empty);

            Cli.Table(Products, TypeTable.Alternative);

            spinner = new ConsoleSpinner
            {
                Delay = 100,
                SpinnerType = ConsoleSpinner.SpinnerTypes.BouncingBall,
                Message = "Cargando",
                SpinnerColor = Color.GreenYellow
            };

            spinner.Start();
            Thread.Sleep(50000);
            spinner.Stop();

            Cli.Info("El proceso finalizo correctamente.");

        }
    }
}