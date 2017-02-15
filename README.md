# cinematic.core

Código base para usar libremente en charlas y eventos. Implementa un sistema muy básico de venta de entradas para un cine. (Versión .NET Core)

## Propósito

El propósito principal de este repositorio es servir de base para la preparación de charlas, talleres y otros eventos de la comunidad técnica [DotNetters Zaragoza](http://dotnetters.es).

## Instalación y ejecución

### Desde Visual Studio (>= 2015)

1. Descargar el código
2. Compilar
3. Ir a la consola del administrador de paquetes (Ver > Otras ventanas > Consola del administrador de paquetes)
4. Seleccionar en el desplegable el proyecto Cinematic.DAL
5. Ejecutar el comando: *Update-Database -Context CinematicEFDataContext**
6. Seleccionar en el desplegable el proyecto Cinematic.Web
7. Ejecutar el comando: *Update-Database -Context ApplicationDbContext*
8. Seleccionar el proyecto web como proyecto de inicio
9. Pulsar F5
