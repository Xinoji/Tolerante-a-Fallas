##### Jonathan Isaac Garcia Huerta
# Manejo de Errores
### Introduccion
Para realizar un correcto uso de los excepciones no solamente es necesario estar utilizando excepciones si no tembien el como manipularlo para cambiar la forma en la que se puede manipular las excepciones, siendo asi es necesario para el correcto funcionamiento, tener formas en las que aunque el programa falle o inclusive suceda una un error imprevisto tener un catch generico o un using.

## Using
Para el uso de using es necesario conocer las cuales son los puntos mas importante que en caso de un error puedan ser sencibles y necesiten un correcto cierre, un caso como este podria ser la conexion a una base de datos SQL, donde si no se cierran las conexiones se puede saturar eventualmente 

``` c#
 using (var connection = GetConnection());
```

dado un caso de ejemplo donde es usado en una consulta es

``` c#
 using (var connection = GetConnection());
    {
        connection.Open();
        using (var command = new SqlCommand())
        {
            decimal totalHoras;
            command.Connection = connection;
            command.CommandText = "select sum(Tiempo_Parada) as HrsParada " +
                "from Reparacion "
            
            var reader = command.ExecuteReader();

            ... //Uso de lo retornado en la Query


        }
    }
```

donde en el contenido que esta en using mantiene en uso la variable declarada, y justo posteriormente de salirse la variable usa el IDispose y realiza una correcta limpieza de los datos.


## Checked / Unchecked
Una forma de controlar errores de forma especifica a los enteros en C# es por medio de los checked o unchecked

Para el uso de Checked unchecked es algo que se realiza principalmente desde el compilador, puesto que por defecto todas las operaciones se hacen desde una evaluacion unchecker, y en caso de cambiar la foma base, donde para cambiar la forma en la que se realiza por defecto se tiene que cambiar en el xml de las propiedades del proyecto:

``` xml
  <CheckForOverflowUnderflow>true</CheckForOverflowUnderflow>
```

Para el checked de forma indivial en una consola es necesario realizar esto de se puede usar de forma individial en el codigo para una instruccion de las siguientnes formas.

``` c#
uint a = uint.MaxValue;

unchecked
{
    Console.WriteLine(a + 1);  
}

try
{
    checked
    {
        Console.WriteLine(a + 1);
    }
}
catch (OverflowException e)
{
    Console.WriteLine(e.Message);  
}
```
En este caso la primera al ser unchecked simplemente realiza la rotacion de bits y pasa a ser 0 y no causa error, pero en el caso de checked no puede realizar la operacion y sucede una excepcion por overflow.


Siendo asi las formas en las que se puede usar checked, que dependiendo como queremos que funcionen las operaciones es las formas en las que se adapta su forma de funcionar.

Para mostrar el funcionamiento y comprobarlo es posible usar el debugger de visual studio y comprobor desde la inspeccion que aunque tengan el mismo valor efectivamente realiza el cambio.

### Conclusiones
Para poder manejar los errores es necesario mantener una conciencia de todas las formas en las que se puede manejar eh incluso en este caso en las formas en las que se puede provocar que sucedan excepciones, puesto que en el caso del checked al forzar que no se pueda sobrepasar puede terminar generando errores que previamente no sucedian, pero esto en caso de que no deba de suceder el pasar de negativo a positivo de golpe o reiniciarse en caso de ser unsigned nos permiten verificar para evitar errores.