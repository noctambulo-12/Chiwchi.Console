# Chiwchi.Console
Inspirado en el objeto *console* de los navegadores se ha creado esta libreria para ayudarnos a mostrar información útil en los proyectos de consola.

## Instalar

#### Nuget
```Console
Install-Package Chiwchi.Console -Version 1.0.0
```

#### .NET CLI 
```Console
dotnet add package Chiwchi.Console --version 1.0.0
```

#### Github 
```Console
dotnet add PROJECT package Chiwchi.Console --version 1.0.0
```

## Cli.table()
Muestra datos tabulares como una tabla.

#### Código:
```C#
//Creamos modelo
class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
}

//Generamos data de prueba
var Products = new List<Product>
{
    new Product {ProductId = 1, ProductName = "Cassette", ProductImageUrl = "product_small_1.png", CreatedDate = DateTime.Now},
    new Product {ProductId = 2, ProductName = "VHS", ProductImageUrl = "product_small_2.png", CreatedDate = DateTime.Now},
    new Product {ProductId = 3, ProductName = "Walkman", ProductImageUrl = "product_small_3.png", CreatedDate = DateTime.Now},
    new Product {ProductId = 4, ProductName = "Discman", ProductImageUrl = "product_small_4.png", CreatedDate = DateTime.Now},
    new Product {ProductId = 5, ProductName = "Diskette", ProductImageUrl = "product_small_5.png", CreatedDate = DateTime.Now}
};

//Mostramos el listado en difere formato 
Console.WriteLine(string.Empty);
Cli.Table(Products);

Console.WriteLine(string.Empty);
Cli.Table(Products,TypeTable.Minimal);

Console.WriteLine(string.Empty);
Cli.Table(Products, TypeTable.Alternative);
```
#### Resultado:
<img src="https://github.com/noctambulo-12/Chiwchi.Console/raw/main/Picture/Cli.Table.png"> 

___

## Cli.Log()

Muestra un mensaje en la consola.

#### Código:
```C#
Cli.Log("¡Hola Perú!", Color.Peru, Color.FromArgb(165, 229, 250));
Cli.Log("¡Hola Perú!", "#bada55", "#222");
Cli.Log("¡Hola Perú!", "007bff", Color.Black);
```
<img src="https://github.com/noctambulo-12/Chiwchi.Console/raw/main/Picture/Cli.Log.png"> 

___

## Cli.Success(), Cli.Warning() y Cli.Error(), 

 - Cli.Success("message"): Muestra un mensaje de **Éxito** en la consola.
 - Cli.Warning("message"): Muestra un mensaje de **advertencia** en la consola.
 - Cli.Error("message"): Muestra un mensaje de **error** en la consola.

#### Código:
```C#
Cli.Success("¡Éxito!");
Cli.Warning("¡Advertencia! Algo no parece correcto.");
Cli.Error("¡Huy! Algo salió mal!");
```

#### Resultado:
<img src="https://github.com/noctambulo-12/Chiwchi.Console/raw/main/Picture/Cli.Status.png"> 

___

## ConsoleSpinner 
 - spinner.Start(): Inicia el subproceso.
 - spinner.Stop(): Termina el subproceso.

#### Código:
```C#
ConsoleSpinner spinner = new ConsoleSpinner();

spinner.Start();
Thread.Sleep(5000); //Aquí debes colocar tú algoritmo 
spinner.Stop();
```
#### Resultado:
<img src="https://github.com/noctambulo-12/Chiwchi.Console/raw/main/Picture/ConsoleSpinner_basic.gif"> 

___

#### Código:
```C#
ConsoleSpinner spinner = new ConsoleSpinner
{
    Delay = 100,
    SpinnerType = ConsoleSpinner.SpinnerTypes.BouncingBall,
    SpinnerColor = Color.GreenYellow
    Message = "Cargando",
};

spinner.Start();
Thread.Sleep(5000); //Aquí debes colocar tú algoritmo 
spinner.Stop();
```
Información de las propiedades utilizadas:
 - **Delay**: Velocidad en milesegundos del spinner
 - **SpinnerType**: Tipo de spinner que se usará
 - **SpinnerColor**: Color del spinner
 - **Message**: Mensaje que se mostrara junto al spinner
 
#### Resultado:
<img src="https://github.com/noctambulo-12/Chiwchi.Console/raw/main/Picture/ConsoleSpinner_full.gif"> 


## Dependencia

#### Pastel
```Console
Install-Package Pastel -Version 2.1.0
```