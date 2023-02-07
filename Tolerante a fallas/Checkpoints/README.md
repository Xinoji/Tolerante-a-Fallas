##### Jonathan Isaac Garcia Huerta 216818631
# Checkpoints

## Introducción
Para poder realizar un trabajo en el que un error inesperado por cualquier medio no perjudique la experiencia del usuario es necesario poner la forma en la que se pueda recuperar la informacion aun despues de que se realice un apagon o una excepcion no controlada por esto es necesario realizar un programa que realice checkpoints sobre la informacion almacenada

## Desarrollo

Primero para poder realizar el programa es necesario tener que almacenar algo que se pueda perder, asi que para realizarlo de una forma rapida directamente realice el almacenamiento de un directorio con solo nombre, telefono y correo electronico para la prueba.

Para realizar principalmente el programa se compone de dos partes, el formulario para el llenado de datos

[Panel Formulario](\assets\Formulario.png "Formulario")

Donde en el formulario posee directamente el formulario para agregar nuevos valores, forzar una ejecucion o borrar directamente los datos para reinicar

[Panel Datos](\assets\Datos.png?raw=true "Datos")

En el panel de datos tenemos directamente los datos ingresados, una checkbox, y un numericUpDown donde el checkbox es para decidir si sera cada vez que se agregue un elemento realizar la serializacion o hacerlo cada X unidad de tiempo, donde el valor del numericUpDown es la cantidad de tiempo que va a tardar

### Serializacion

Para realizar la serializacion de los datos ingresados se realiza mediante la libreria ` System.Runtime.Serialization.Formatters.Binary;`
usando especificamente la funcion `BinaryFormatter()` tanto para serializar como para deserializar.

El proceso para serializar es primero obtener los valores de DataGridView y almacenarlo en un array bidimencional `object[,]`

y posteriormente por medio de esta funcion generica serializamos
``` C#
public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
{
    using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
    {
        var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        binaryFormatter.Serialize(stream, objectToWrite);
    }
}
```

donde este funcion principalmente recive el array de objetos, el directorio del archivo y en dado caso de necesesitarlo ver si se agregara al final o no, en mi caso en algun punto se planteo que los datos se realizara un append, pero como no se concreto se dejo en la funicion con un parametro predefinido, con esto simplemente se abre un archivo en forma de crear y se inserta en bruto el binario de los objetos

para deserializar se hace con la misma funcion pero de forma inversa

``` c#
public static T ReadFromBinaryFile<T>(string filePath)
{
    using (Stream stream = File.Open(filePath, FileMode.Open))
    {
        var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        return (T)binaryFormatter.Deserialize(stream);
    }
}
```

Donde en este simplmente realizamos la apertura del archivo y retornamos su contenido casteandolo como el tipo que necesitamos, en este caso un `object[,]` y simplemente con este proceso se realiza el sistema, donde el respaldo serializado se guarda en el archivo backup.bin y en caso de que sea necesario siempre se puede reiniciar el archivo de backup.

## Conclusión
El desarrollo de esta practica concrete parte de los conocimientos adquiridos en estructura de datos al tener que seralizar un objeto para poder realizar realizar el almacenamiento, asi que utilizando metodos para serializar directo desde bytes puesto que la recuperacion del objeto es directa y no se tiene que realizar un proceso tan grande para la recuperacion, teniendo al principio intentar serializarlo desde JSON pero implicaba mas procedimiento y al momento de empezar a agregar grandes cantidades de datos empezaba a realentisarse la ejecución provocando, mientras que la serializacion y deserializacion con BinnaryFormater en C#.

## Bibliografia
McCluskey, G. (2005). working with C# serialization. ; login:: the magazine of USENIX & SAGE, 30(1), 59-63.