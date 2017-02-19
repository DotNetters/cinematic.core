# cinematic.core (Versión .NET Core)

Implementa un sistema muy básico de venta de entradas para un cine (modo TPV).

## Propósito

El propósito principal de este repositorio es servir de base para la preparación de charlas, talleres y otros eventos de la comunidad técnica [DotNetters Zaragoza](http://dotnetters.es), pero puede jugar con él quien quiera, barra libre.

## Instalación y ejecución

### Requisitos para el entorno de desarrollo

- **IDE**
  - **Sólo windows:** [Visual Studio (sirven las ediciones Community)](https://www.visualstudio.com/es/downloads/)
    - Visual Studio 2015 (Update 3) o Visual Studio 2017
  - **Windows, Linux, MacOS:** [Visual Studio Code](http://code.visualstudio.com/)
- [**.NET Core**](https://www.microsoft.com/net/core): En el enlace están las instrucciones de instalación para todas las plataformas y todos los IDE, seleccionar el entorno según se haya montado
- Acceso a datos
  - [**SQL Server**](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
    - Sirven las ediciones [Developer](https://my.visualstudio.com/Benefits?Wt.mc_id=o~msft~sql-server-dev-edition&campaign=o~msft~sql-server-dev-edition) o [Express](https://go.microsoft.com/fwlink/?LinkID=799012) (gratuitas).
    - Hay una versión [v.Next para Linux](https://www.microsoft.com/es-es/sql-server/sql-server-vnext-including-Linux)
  - Rehaciendo las migrations, y retocando la clase Startup del proyecto web se puede usar 
    - [SQLite](https://www.sqlite.org/)
    - [PostgreSQL](https://www.postgresql.org/)
    - [MySQL](https://www.mysql.com/)


### Desde Visual Studio (>= 2015) (Sólo windows)

Descargar el código desde github con la herramienta integrada en Visual Studio

Compilar

Seleccionar el proyecto web como proyecto de inicio

Para generar la BBDD, ir a la consola del administrador de paquetes (Ver > Otras ventanas > Consola del administrador de paquetes)
   - Seleccionar en el desplegable el proyecto Cinematic.DAL
   - Ejecutar el comando: 
```<bash>
Update-Database -Context CinematicEFDataContext
```
   - Seleccionar en el desplegable el proyecto Cinematic.Web
   - Ejecutar el comando: 
```<bash>
Update-Database -Context ApplicationDbContext
```

Pulsar F5

### Con Visual Studio Code (Windows, Linux, MacOS)

Clonar el proyecto desde github
```<bash>
git clone https://github.com/DotNetters/cinematic.core.git
```

Desde la raíz del proyecto (por ejemplo /home/[user]/work/cinematic.core), ejecutar 
```<bash>
dotnet restore
```

Para generar la base de datos: 
  - Desde la carpeta del proyecto DAL (por ejemplo /home/[user]/work/cinematic.core/src/Cinematic.DAL)
```<bash>
dotnet ef --startup-project /home/[user]/work/cinematic.core/src/Cinematic.Web database update --context CinematicEFDataContext --verbose
```
  - Desde la carpeta del proyecto WEB (por ejemplo /home/[user]/work/cinematic.core/src/Cinematic.Web)
```<bash>
dotnet ef --startup-project /home/[user]/work/cinematic.core/src/Cinematic.Web database update --context ApplicationDbContext --verbose
```

Instalar bower si no lo tenemos instalado
```<bash>
npm install -g bower
```

Desde la carpeta del proyecto web (por ejemplo /home/[user]/work/cinematic.core/src/Cinematic.Web), ejecutar
```<bash>
bower install 
```

Desde la carpeta del proyecto web (por ejemplo /home/[user]/work/cinematic.core/src/Cinematic.Web), ejecutar
```<bash>
dotnet run 
```

Apuntar con el navegador web a la URL http://localhost:5000

Para ejecutar las pruebas unitarias (C#), ir a la carpeta del proyecto de pruebas unitarias (por ejemplo /home/[user]/work/cinematic.core/test/Cinematic.Core.Tests) y ejecutar
```<language>
dotnet test
```

Para desarrollar con el editor, abrir desde VS Code la carpeta raíz del proyecto (por ejemplo /home/[user]/work/cinematic.core)
```<bash>
code .
```
